using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3 {
    class Merchandise {

        public Merchandise(int id, string name, int quantity, int price) {  // Add merchandise object
            productID = id;
            productName = name;
            productQuantity = quantity;
            productPrice = price;
        }

        int productID;
        string productName;
        int productQuantity;
        int productPrice;

        public void editMerchandise(int id, string name, int quantity, int price) {  // Edit merchandise
            productID = id;
            productName = name;
            productQuantity = quantity;
            productPrice = price;
        }

        public void deleteMerchandise() {  // Edit merchandise
            productID = 0;
            productName = "";
            productQuantity = 0;
            productPrice = 0;
        }
    }
}
