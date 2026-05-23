import re

with open(r"c:\Users\Jan Javer Valery C\OneDrive\Documents\FINALS-IM-master\FINALS-IM-master\InformationManagement\Admin\burger_system_schema.sql", "r", encoding="latin-1") as f:
    content = f.read()

m = re.search(r"CREATE TABLE `orders`.*?;", content, re.DOTALL)
if m:
    print("orders: " + m.group(0)[:100] + "...")
else:
    print("orders not found")

m2 = re.search(r"CREATE TABLE `order`.*?;", content, re.DOTALL)
if m2:
    print("order: " + m2.group(0))
else:
    print("order not found")
