import os

filepath = r"c:\Users\Jan Javer Valery C\OneDrive\Documents\FINALS-IM-master\FINALS-IM-master\InformationManagement\Admin\FormEditMenu.vb"

try:
    with open(filepath, "r", encoding="utf-8") as f:
        content = f.read()
    enc = "utf-8"
except UnicodeDecodeError:
    with open(filepath, "r", encoding="latin-1") as f:
        content = f.read()
    enc = "latin-1"

old_block = """        cmbCategory.Items.Add("SPAGHETTI MEAL")
        cmbCategory.Items.Add("DESSERT")
        cmbCategory.Items.Add("DRINKS & BEVERAGES")
        cmbCategory.Items.Add("PLATTER")
        cmbCategory.Items.Add("RICE MEAL")
        cmbCategory.Items.Add("RICE")
        cmbCategory.Items.Add("NOODLES & PASTA") ' Database value for "Bilao"
        cmbCategory.Items.Add("Snacks")"""

new_block = """        cmbCategory.Items.Add("Burgers")
        cmbCategory.Items.Add("Sides")
        cmbCategory.Items.Add("Silog Meals")
        cmbCategory.Items.Add("Drinks")"""

new_content = content.replace(old_block, new_block)

if new_content != content:
    with open(filepath, "w", encoding=enc) as f:
        f.write(new_content)
    print("Fixed FormEditMenu.vb categories")
else:
    print("Could not find block in FormEditMenu.vb")
