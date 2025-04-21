export default function RootLayout({ children }) {
    return (
      <html lang="en">
        <body>
          <nav style={{ padding: '1rem', backgroundColor: '#f5f5f5' }}>
            <a href="/" style={{ marginRight: '1rem' }}>Home</a>
            <a href="/add-student" style={{ marginRight: '1rem' }}>Add Student</a>
            <a href="/create-student" style={{ marginRight: '1rem' }}>Create Student</a>
            <a href="/add-section" style={{ marginRight: '1rem' }}>Add Section</a>
            <a href="/create-section">Create Section</a>
          </nav>
          <main style={{ padding: '2rem' }}>
            {children}
          </main>
        </body>
      </html>
    );
  }
  