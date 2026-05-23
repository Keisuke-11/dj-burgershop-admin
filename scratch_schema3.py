import re

with open(r"c:\Users\Jan Javer Valery C\OneDrive\Documents\FINALS-IM-master\FINALS-IM-master\InformationManagement\Admin\burger_system_schema.sql", "r", encoding="latin-1") as f:
    content = f.read()

def check_table(tname):
    m = re.search(f"CREATE TABLE `{tname}`", content, re.DOTALL)
    if m:
        print(f"Table {tname} EXISTS")
    else:
        print(f"Table {tname} does NOT exist")

check_table("product")
check_table("products")
check_table("ingredient")
check_table("ingredients")
check_table("reservation")
check_table("reservations")
check_table("order")
check_table("orders")
check_table("inventory_batches")
check_table("inventory_finished")
