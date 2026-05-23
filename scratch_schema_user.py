import re

with open(r"c:\Users\Jan Javer Valery C\OneDrive\Documents\FINALS-IM-master\FINALS-IM-master\InformationManagement\Admin\burger_system_schema.sql", "r", encoding="latin-1") as f:
    content = f.read()

m = re.search(r"CREATE TABLE `user_accounts`.*?;", content, re.DOTALL)
if m:
    print(m.group(0))
