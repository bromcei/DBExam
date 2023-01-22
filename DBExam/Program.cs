// See https://aka.ms/new-console-template for more information

using DBExam.Classes;
using DBExam.DbContextServer;
using DBExam.Repositories;

HoneyBadgerDbContext honeyDb = new HoneyBadgerDbContext();

SuppliersRepository Supliers = new SuppliersRepository();
HoneyProductsRepository HoneyProducts = new HoneyProductsRepository();
DepartmentsRepository Departments = new DepartmentsRepository();


//Department kaunasDepartment = new Department("Kaunas", "Laisves aleja 1");

HoneyProduct prod1 = new HoneyProduct("Liepu Medus", 2.5m);
HoneyProduct prod2 = new HoneyProduct("Klevu Medus", 3.0m);
HoneyProduct prod3 = new HoneyProduct("Rapsu Medus", 1.2m);
HoneyProduct prod4 = new HoneyProduct("Ievu Medus", 4.5m);
HoneyProduct prod5 = new HoneyProduct("Obelu Medus", 1.8m);
HoneyProduct prod6 = new HoneyProduct("Pieniu Medus", 2.2m);

Departments.AddProductsToDepartment("Kaunas", new List<HoneyProduct>() { prod1, prod2, prod3, prod4, prod5, prod6 });

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


