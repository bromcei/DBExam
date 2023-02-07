// See https://aka.ms/new-console-template for more information

using DBExam.Classes;
using DBExam.Services;

RecordEditorService RecordEditorService = new RecordEditorService();
ReportService ReportService = new ReportService();

string userInput = "";
while (userInput != "quit")
{
    Console.WriteLine("Menu:");
    Console.WriteLine("Press 1 to list all Departments");
    Console.WriteLine("Press 2 to list all Suppliers");
    Console.WriteLine("Press 3 to list all Honey Products");
    Console.WriteLine("Press 4 to add new Department");
    Console.WriteLine("Press 5 to add new Product");
    Console.WriteLine("Press 6 to add new Supplier");
    Console.WriteLine("Press 7 to assign Supplier to Department");
    Console.WriteLine("Press 8 to transfer Product to other Department(changes suppliers too)");
    Console.WriteLine("Press 9 to list all department Products");
    Console.WriteLine("Press 10 to list all department Suppliers");
    Console.WriteLine("Press 11 to list all Product Suppliers");

    Console.WriteLine("Type \"quit\" to quit application");

    userInput = Console.ReadLine();

    switch (userInput)
    {
        case "1":
            Console.WriteLine(ReportService.ShowAllDepartments());
            break;

        case "2":
            Console.WriteLine(ReportService.ShowAllSuppliers());
            break;

        case "3":
            Console.WriteLine(ReportService.ShowAllProducts());
            break;
        case "4":
            Console.WriteLine("Add new Department to HoneyBadgerDB");
            Console.WriteLine("New Department Name: ");
            string departmentName = Console.ReadLine();
            Console.WriteLine("New Department Address: ");
            string departmentAddress = Console.ReadLine();
            Department departmentToAdd = new Department(departmentName, departmentAddress);
            RecordEditorService.AddNewDepartment(departmentToAdd);
            Console.WriteLine($"Department {departmentName} Was add to db.");
            break;

        case "5":
            Console.WriteLine("Add new Product to HoneyBadgerDB");
            Console.WriteLine("New Product Name: ");
            string productName = Console.ReadLine();
            Console.WriteLine("New Product Purchase Price: ");
            string purchasePriceString = Console.ReadLine();
            Console.WriteLine("New Product DepartmentID: ");
            string departmentIDString = Console.ReadLine();
            decimal purchasePrice;
            int departmentID;
            
            if (decimal.TryParse(purchasePriceString, out purchasePrice) && int.TryParse(departmentIDString, out departmentID)) {
                HoneyProduct newProd = new HoneyProduct(productName, purchasePrice);
                RecordEditorService.AddNewHoneyProduct(newProd, departmentID);
                RecordEditorService.AssignDepartmentSuppliersToProduct(RecordEditorService.HoneyProductsRepository.Retrieve(productName).HoneyId);
                Console.WriteLine($"Product {productName} was add to db.");
            }
            else
            {
                Console.WriteLine("Bad purchase format data type or no such department in database");
            }
            break;

        case "6":
            Console.WriteLine("Add new Supplier to HoneyBadgerDB");
            Console.WriteLine("New Supplier Name: ");
            string supplierName = Console.ReadLine();
            Console.WriteLine("New Supplier Address: ");
            string supplierAddress = Console.ReadLine();
            Supplier supplierAddressToAdd = new Supplier(supplierName, supplierAddress);
            int newSupplierID = RecordEditorService.AddNewHoneySupplier(supplierAddressToAdd);
            Console.WriteLine($"Supplier {supplierName} Was add to db.");
            Console.WriteLine($"Assign new Supplier to department? Input DepartmentID or type 'No'");
            string ifAssignToDepartment = Console.ReadLine();
            int departmentIDtoAssign;
            if (int.TryParse(ifAssignToDepartment, out departmentIDtoAssign))
            {
                RecordEditorService.AssignSupplierToDepartment(
                    newSupplierID,
                    departmentIDtoAssign);
                Console.WriteLine("Supplier assigned to designated department.");
            }
            break;

        case "7":
            Console.WriteLine("Assign Supplier to Department");
            Console.WriteLine("Supplier ID: ");
            string supplierIDString = Console.ReadLine();
            Console.WriteLine("Department ID: ");
            string departmentIDstring = Console.ReadLine();
            int supplierID;
            int departmentID1;

            if (int.TryParse(supplierIDString, out supplierID) && int.TryParse(departmentIDstring, out departmentID1)) {
                RecordEditorService.AssignSupplierToDepartment(supplierID, departmentID1);
            }
            else
            {
                Console.WriteLine("Bad input format");
            }
            break;

        case "8":
            Console.WriteLine("Transfer Product to Department");
            Console.WriteLine("Product ID: ");
            string prodIDString = Console.ReadLine();
            Console.WriteLine("Department ID: ");
            string departmentIDstringP = Console.ReadLine();
            int prodID;
            int departmentID2;

            if (int.TryParse(prodIDString, out prodID) && int.TryParse(departmentIDstringP, out departmentID2))
            {
                RecordEditorService.ChangeProductDepartmentAndSuppliers(prodID, departmentID2);
            }
            else
            {
                Console.WriteLine("Bad input format");
            }
            break;

        case "9":
            Console.WriteLine("Department ID: ");
            string departmentIDProductsString = Console.ReadLine();
            int departmentIDProducts;

            if (int.TryParse(departmentIDProductsString, out departmentIDProducts))
            {
                Console.WriteLine(ReportService.ShowAllDepartmentProducts(departmentIDProducts));
            }
            else
            {
                Console.WriteLine("Bad input format");
            }
            break;

        case "10":
            Console.WriteLine("Department ID: ");
            string departmentIDSuppliersString = Console.ReadLine();
            int departmentIDSuppliers;

            if (int.TryParse(departmentIDSuppliersString, out departmentIDSuppliers))
            {
                Console.WriteLine(ReportService.ShowAllDepartmentSuppliers(departmentIDSuppliers));
            }
            else
            {
                Console.WriteLine("Bad input format");
            }
            break;

        case "11":
            Console.WriteLine("Product ID: ");
            string productIDSuppliersString = Console.ReadLine();
            int productIDSuppliers;

            if (int.TryParse(productIDSuppliersString, out productIDSuppliers))
            {
                Console.WriteLine(ReportService.ShowAllProductSuppliers(productIDSuppliers));
            }
            else
            {
                Console.WriteLine("Bad input format");
            }
            break;


        default:
            // code block
            break;
    }
}



