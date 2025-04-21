using Microsoft.AspNetCore.Mvc;
using static System.Collections.Specialized.BitVector32;

[Route("api/[controller]")]
[ApiController]
public class SectionsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public SectionsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult> CreateSection(SectionDTO sectionDto)
    {
        var subjectExists = await _context.Subjects.AnyAsync(s => s.Id == sectionDto.SubjectId);
        if (!subjectExists)
            return BadRequest("Invalid subject ID.");

        var section = new Section
        {
            Name = sectionDto.Name,
            SubjectId = sectionDto.SubjectId
        };

        _context.Sections.Add(section);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetSection), new { id = section.Id }, section);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Section>> GetSection(int id)
    {
        var section = await _context.Sections
            .Include(s => s.StudentSections)
            .ThenInclude(ss => ss.Student)
            .FirstOrDefaultAsync(s => s.Id == id);

        if (section == null)
            return NotFound();

        return section;
    }
}
