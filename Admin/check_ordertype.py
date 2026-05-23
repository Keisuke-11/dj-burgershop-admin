import mysql.connector

try:
    conn = mysql.connector.connect(
        host="127.0.0.1",
        user="root",
        password="",
        database="burger_system"
    )
    cursor = conn.cursor()
    
    print("Checking OrderType distribution:")
    cursor.execute("SELECT OrderType, COUNT(*) FROM orders GROUP BY OrderType")
    rows = cursor.fetchall()
    for row in rows:
        print(f"'{row[0]}': {row[1]}")
    
    print("\nChecking enum definition for OrderType:")
    cursor.execute("SHOW COLUMNS FROM orders LIKE 'OrderType'")
    col = cursor.fetchone()
    print(f"Type: {col[1]}")
    
    cursor.close()
    conn.close()
except Exception as e:
    print(f"Error: {e}")
