import pyodbc

try:
    conn_str = "Driver={ODBC Driver 17 for SQL Server};Server=.;Database=EverGlow;Trusted_Connection=yes;"
    conn = pyodbc.connect(conn_str)
    cursor = conn.cursor()
    cursor.execute("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE'")
    tables = [row[0] for row in cursor.fetchall()]
    print("Tables in EverGlow:", tables)
    conn.close()
except Exception as e:
    print("Error:", e)
