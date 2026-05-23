import os
import re

project_dir = r"c:\Users\Jan Javer Valery C\OneDrive\Documents\FINALS-IM-master\FINALS-IM-master\InformationManagement"

def fix_payment_queries():
    for root, _, files in os.walk(project_dir):
        for file in files:
            if file.endswith(".vb"):
                filepath = os.path.join(root, file)
                try:
                    with open(filepath, "r", encoding="utf-8") as f:
                        content = f.read()
                    enc = "utf-8"
                except UnicodeDecodeError:
                    with open(filepath, "r", encoding="latin-1") as f:
                        content = f.read()
                    enc = "latin-1"
                
                replacements = {
                    "FROM payment WHERE PaymentDate IS NOT NULL AND ReservationID IS NOT NULL": "FROM reservationpayment WHERE PaymentDate IS NOT NULL",
                    "FROM payment WHERE YEAR(PaymentDate) = @Year AND ReservationID IS NOT NULL": "FROM reservationpayment WHERE YEAR(PaymentDate) = @Year",
                    "FROM payment WHERE ReservationID IS NOT NULL AND PaymentStatus = 'Completed'": "FROM reservationpayment WHERE PaymentStatus = 'Completed'",
                    "FROM payment rp": "FROM reservationpayment rp", 
                    "FROM payment WHERE ReservationID = @reservationID": "FROM reservationpayment WHERE ReservationID = @reservationID",
                    "FROM payment p\n        WHERE p.ReservationID IS NOT NULL": "FROM reservationpayment p\n        WHERE p.ReservationID IS NOT NULL",
                    "FROM payment WHERE PaymentDate IS NOT NULL AND ReservationID IS NOT NULL": "FROM reservationpayment WHERE PaymentDate IS NOT NULL",
                    "FROM payment WHERE ReservationID IS NOT NULL": "FROM reservationpayment",
                    "FROM payment\n                                     WHERE ReservationID IS NOT NULL": "FROM reservationpayment\n                                     WHERE ReservationID IS NOT NULL",
                    "SELECT COUNT(DISTINCT ReservationID) FROM payment": "SELECT COUNT(DISTINCT ReservationID) FROM reservationpayment",
                    "SELECT COUNT(DISTINCT ReservationID) FROM payment ": "SELECT COUNT(DISTINCT ReservationID) FROM reservationpayment ",
                }
                
                new_content = content
                for old, new in replacements.items():
                    new_content = new_content.replace(old, new)
                
                # regex fix
                new_content = re.sub(r'FROM payment\s+WHERE ReservationID IS NOT NULL', r'FROM reservationpayment WHERE 1=1', new_content)

                if new_content != content:
                    with open(filepath, "w", encoding=enc) as f:
                        f.write(new_content)
                    print(f"Fixed payment->reservationpayment in {file}")

fix_payment_queries()
