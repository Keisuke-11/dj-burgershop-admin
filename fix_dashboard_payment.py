import os

filepath = r"c:\Users\Jan Javer Valery C\OneDrive\Documents\FINALS-IM-master\FINALS-IM-master\InformationManagement\Admin\Dashboard.vb"

try:
    with open(filepath, "r", encoding="utf-8") as f:
        content = f.read()
    enc = "utf-8"
except UnicodeDecodeError:
    with open(filepath, "r", encoding="latin-1") as f:
        content = f.read()
    enc = "latin-1"

# Replace instances where payment is queried for reservations
new_content = content.replace(
    "FROM payment WHERE ReservationID IS NOT NULL", 
    "FROM reservationpayment WHERE ReservationID IS NOT NULL"
)

# And line 638: "WHERE rp.ReservationID IS NOT NULL"
# Let's check what it is
# Actually, the python script below will print the diff.

if new_content != content:
    with open(filepath, "w", encoding=enc) as f:
        f.write(new_content)
    print("Fixed ReservationID queries in Dashboard.vb")
else:
    print("No changes made to Dashboard.vb")
