// See https://aka.ms/new-console-template for more information

using DBExam.Classes;
using DBExam.DbContextServer;
using DBExam.Repositories;

HoneyBadgerDbContext honeyDb = new HoneyBadgerDbContext();

SuppliersRepository Suppliers = new SuppliersRepository();
HoneyProductsRepository HoneyProducts = new HoneyProductsRepository();
DepartmentsRepository Departments = new DepartmentsRepository();


Department vilnius = new ("Vilnius", "Gedimino pr.1, Vilnius");
Department kaunas = new ("Kaunas", "Laisves aleja 1, Kaunas");

//Products
HoneyProduct prod1 = new HoneyProduct("Liepu Medus", 2.5m);
HoneyProduct prod2 = new HoneyProduct("Klevu Medus", 3.0m);
HoneyProduct prod3 = new HoneyProduct("Rapsu Medus", 1.2m);
HoneyProduct prod4 = new HoneyProduct("Ievu Medus", 4.5m);
HoneyProduct prod5 = new HoneyProduct("Obelu Medus", 1.8m);
HoneyProduct prod6 = new HoneyProduct("Pieniu Medus", 2.2m);

//Suppliers
Supplier kaimoBites = new Supplier("Kaimo Bites", "Lauzu g. 1, Garliava, Kauno r.");
Supplier piktosBites = new Supplier("Piktos Bites", "Alyvu g. 5A, Ringaudai, Kauno r.");
Supplier miestoBites = new Supplier("Miesto Bites", "Traku g. 15, Trakai");
Supplier miskoBites = new Supplier("Misko Bites", "Pusyno g. 3, Varena");

//Department Suppliers
kaunas.Suppliers = new List<Supplier>() { kaimoBites, piktosBites };
vilnius.Suppliers = new List<Supplier>() { miestoBites, miskoBites };


//Departments.AddDepartment(kaunasDepartment);
//prod_list new List<HoneyProduct>() { prod1, prod2, prod3, prod4, prod5, prod6 }
vilnius.HoneyProducts = new List<HoneyProduct>() { prod1, prod2, prod3, prod4, prod5, prod6 };
kaunas.HoneyProducts = new List<HoneyProduct> { prod1, prod2, prod5, prod6 };
Departments.AddDepartment(vilnius);
Departments.AddDepartment(kaunas);

HoneyProducts.AddNewProducts(new List<HoneyProduct>() { prod1, prod2, prod3, prod4, prod5, prod6 });
Suppliers.AddNewSupplier(kaimoBites);
Suppliers.AddNewSupplier(piktosBites);
Suppliers.AddNewSupplier(miestoBites);
Suppliers.AddNewSupplier(miskoBites);

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


