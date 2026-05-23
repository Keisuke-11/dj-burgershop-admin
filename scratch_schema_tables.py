import re

with open(r"c:\Users\Jan Javer Valery C\OneDrive\Documents\FINALS-IM-master\FINALS-IM-master\InformationManagement\Admin\burger_system_schema.sql", "r", encoding="latin-1") as f:
    content = f.read()

# Find all table names in the schema
tables = re.findall(r"CREATE TABLE `([^`]+)`", content)
print("Tables in schema:")
for t in tables:
    print(f"- {t}")
