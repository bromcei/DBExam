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
            RecordEditorService.AddNewHoneySupplier(supplierAddressToAdd);
            Console.WriteLine($"Supplier {supplierName} Was add to db.");
            Console.WriteLine($"Assign new Supplier to department? Input DepartmentID or type 'No'");
            string ifAssignToDepartment = Console.ReadLine();
            int departmentIDtoAssign;
            if (int.TryParse(ifAssignToDepartment, out departmentIDtoAssign))
            {
                RecordEditorService.AssignSupplierToDepartment(
                    RecordEditorService.SuppliersRepository.Retrieve(supplierName).SupplierId,
                    departmentIDtoAssign);
                Console.WriteLine("Supplier assigned to designated department.");
            }
            break;


        default:
            // code block
            break;
    }
}



/*
//RecordEditorService.AddNewDepartment(new Department("Kaunas", "Laisves al. 1, Kaunas"));
RecordEditorService.AddNewHoneyProduct(new HoneyProduct("Liepu Medus", 1.5M), "Kaunas");
*/
/*
SuppliersRepository Suppliers = new SuppliersRepository();
HoneyProductsRepository HoneyProducts = new HoneyProductsRepository();
DepartmentsRepository Departments = new DepartmentsRepository();
HoneyBadgerDbContext honeyDb = new HoneyBadgerDbContext();
using (honeyDb)
{
    DepartmentSupplier newRecord = new DepartmentSupplier();
    Department kaunas = honeyDb.Departments.SingleOrDefault(d => d.DepartmentName == "Kaunas");
    Supplier sup = honeyDb.Suppliers.SingleOrDefault(s => s.SupplierName == "Kaimo Bites");
    newRecord.Department = kaunas;
    newRecord.Supplier = sup;

    honeyDb.DepartmentSuppliers.Add(newRecord);

    honeyDb.SaveChanges();
}
*/
//honeyDb.Departments
/*
Department vilnius = new ("Vilnius", "Gedimino pr.1, Vilnius");
Department kaunas = new ("Kaunas", "Laisves aleja 1, Kaunas");
*/
//Products
/*
HoneyProduct prod1 = new HoneyProduct("Liepu Medus", 2.5m);
HoneyProduct prod2 = new HoneyProduct("Klevu Medus", 3.0m);
HoneyProduct prod3 = new HoneyProduct("Rapsu Medus", 1.2m);
HoneyProduct prod4 = new HoneyProduct("Ievu Medus", 4.5m);
HoneyProduct prod5 = new HoneyProduct("Obelu Medus", 1.8m);
HoneyProduct prod6 = new HoneyProduct("Pieniu Medus", 2.2m);
*/
//Suppliers
/*
Supplier kaimoBites = new Supplier("Kaimo Bites", "Lauzu g. 1, Garliava, Kauno r.");
Supplier piktosBites = new Supplier("Piktos Bites", "Alyvu g. 5A, Ringaudai, Kauno r.");
Supplier miestoBites = new Supplier("Miesto Bites", "Traku g. 15, Trakai");
Supplier miskoBites = new Supplier("Misko Bites", "Pusyno g. 3, Varena");
*/
//Department Suppliers
/*
kaunas.Suppliers = new List<Supplier>() { kaimoBites, piktosBites };
vilnius.Suppliers = new List<Supplier>() { miestoBites, miskoBites };
*/

//Departments.AddDepartment(kaunasDepartment);
//prod_list new List<HoneyProduct>() { prod1, prod2, prod3, prod4, prod5, prod6 }
/*
vilnius.HoneyProducts = new List<HoneyProduct>() { prod1, prod2, prod3, prod4, prod5, prod6 };
kaunas.HoneyProducts = new List<HoneyProduct> { prod1, prod2, prod5, prod6 };
Departments.AddDepartment(vilnius);
Departments.AddDepartment(kaunas);
*/


//HoneyProducts.AddNewProducts(new List<HoneyProduct>() { prod1, prod2, prod3, prod4 });
/*
Supplier kaimoBites = new Supplier("Kaimo Bites", "Lauzu g. 1, Garliava, Kauno r.");
Supplier piktosBites = new Supplier("Piktos Bites", "Alyvu g. 5A, Ringaudai, Kauno r.");

Supliers.AddNewSupplier(kaimoBites);
Supliers.AddNewSupplier(piktosBites);
*/
/*
Supliers.Retrieve("Kaimo Bites").AddProducts(new List<HoneyProduct>() { prod1, prod2, prod3, prod4 });
Supliers.Retrieve("Piktos Bites").AddProducts(new List<HoneyProduct>() { prod3, prod4, prod5, prod6 });

honeyDb.SaveChanges();
*/


