using Laborator_24___Exercitiu.Departments;
using Laborator_24___Exercitiu.Exceptions;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Laborator_24___Exercitiu
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initializati sistemul de gestiune iar apoi, cu ajutorul task-urilor paralele, apelati metodele sistemului de 
            // gestiune a angajatilor pentru a va asigura ca functionarea sistemului este corecta.Efectuati urmatoarele
            // operatii in mod concurent.

            // - Adaugare de angajati
            // - Stergere de angajat
            // - GetEmployeesByDepartment
            //-  IncreaseSalary
            #region Exercise
            /*
               Scrieti un sistem de gestiune a angajatilor.
                Angajatul va fi caracterizat de
                    • Nume
                    • Id :Guid
                    • Salary : double
                    • Department
                    • ToString – returneaza intr-o maniera prietenoasa toate informatiile despre angajat
                Departamentele pot fi
                    • Development
                    • Testing
                    • HumanResources
                    • Maintenance
                    • Logistics
                Sistemul de gestiune va fi unic la nivel de aplicatie si va fi modelat de o clasa care va avea urmatoarele :
                    • AddEmployee
                        o Adauga un angajat dat ca parametru
                    • RemoveEmployee
                        o Sterge un angajat in functie de ID-ul acestuia
                    • GetNoOfWellPayedEmployees
                        o Metoda va primi ca parametru o valoare numerica si va returna o lista cu toti angajatii cu salariul mai mare decat valoarea numerica oferita ca parametru
                    • GetEmployeesByDepartment
                        o Va primi ca parametru un departament si va returna o lista cu toti angajatii din acel departament
                    • GetMaxSalary
                        o O metoda fara parametri, care va returna angajatii cu cel mai mare salariu la nivel de companie
                    • GetMaxSalary
                        o Metoda va primi ca parametru un departament si va returna angajatii cu cel mai mare salariu din departamentul oferit ca parametru.
                    • GetTotalCost
                        o Metoda va returna o valoare numerica reprezentand suma tuturor salariilor din companie
                    • GetCostForDepartment
                        o Metoda va returna o valoare numerica reprezentand suma tuturor salariilor din departamentul oferit ca parametru
                    • IncreaseSalary
                        o Metoda va primi doi parametri, ID-ul angajatului si un procent si va mari salariul angajatului cu procentul dat ca parametru
                    • IncreaseSalary
                        o Metoda va primi doi parametri, un departament si un procent si va mari salariile tuturor angajatilor din acel departament cu procentul dat ca parametru
                Instantiati clasele, adaugati angajati, accesati metodele, afisati rezultatele. Folositi expresii lambda, functiile clasei List<T>: ForEach, FindAll, Count.
                     NU folositi instructiunea foreach:
                Suplimentar 2
                Sistemul de gestiune va fi unic la nivel de aplicatie si modelat de o clasa care va avea urmatoarele :
                 • GetMaxSalary
                    o Metoda va primi ca parametru o lista de departamente si va returna angajatii cu cel mai mare salariu din departamentele oferite ca parametru.
                 • IncreaseSalary
                    o Metoda va primi doi parametri, o lista de departamente si un procent si va mari salariile tuturor angajatilor din departamentele specificate cu procentul dat ca parametru
                 • GetMaxSalaryByDepartment
                    o Metoda va primi ca parametru o lista de departamente si va returna pentru fiecare departament, angajatii cu cel mai mare salariu.
                Aruncati exceptiile necesare.
            */
            #endregion

            #region Employees
            Employee bogdan = new Employee("Bogdan", 8_200d, HumanResourcesDepartment.Instance);
            Employee mihai = new Employee("Mihai", 1_000d, HumanResourcesDepartment.Instance);
            Employee alexandra = new Employee("Alexandra", 2_820d, MaintenanceDepartment.Instance);
            Employee boca = new Employee("Boca", 3_250d, TestingDepartment.Instance);
            Employee mihaela = new Employee("Mihaela", 3_500d, TestingDepartment.Instance);
            #endregion
            #region Adding employees
            {
                var task1 = Task.Run(() =>
                {
                lock (locker)

                TryToAddEmployee(bogdan);
                TryToAddEmployee(mihai);
                TryToAddEmployee(alexandra);
                TryToAddEmployee(boca);
                TryToAddEmployee(mihaela);
                Thread.Sleep(100);
                Console.WriteLine();
                });
            
            #endregion
            
                var task2 = Task.Run(() =>
                {
                    lock (locker)

                    TryToAddEmployee(mihaela);
                    Thread.Sleep(100);
                    Console.WriteLine();
                });
            
            
                var task3 = Task.Run(() =>
                {
                lock (locker)

                TryToRemoveLazyEmployee(mihai.ID);
                TryToRemoveLazyEmployee(mihai.ID);
                Thread.Sleep(100);
                Console.WriteLine();
                });
            
            
                var task4 = Task.Run(() =>
                {
                lock (locker)

                TryGetEmployeesByDepartment(HumanResourcesDepartment.Instance);
                TryGetEmployeesByDepartment(LogisticsDepartment.Instance);
                Thread.Sleep(100);
                Console.WriteLine();
                });
            
            
                var task5 = Task.Run(() =>
                {
                lock (locker)

                TryIncreasingSalary(mihai.ID, 10d);
                TryIncreasingSalary(alexandra.ID, 15d);
                TryIncreasingSalary(boca.ID, 11.6d);
                Console.WriteLine();


                TryIncreasingSalary(TestingDepartment.Instance, 12.5d);
                TryIncreasingSalary(DevelopmentDepartment.Instance, 16.4d);
                TryIncreasingSalary(LogisticsDepartment.Instance, 13.7d);
                Console.WriteLine();


                List<IDepartment> listOfDepartments = new List<IDepartment>
            {   HumanResourcesDepartment.Instance,
                DevelopmentDepartment.Instance,
                LogisticsDepartment.Instance
            };

                TryIncreasingSalary(listOfDepartments, 7.5d);
                Console.WriteLine();


                TryGetMaxSalary();
                Console.WriteLine();

                TryGetMaxSalary(LogisticsDepartment.Instance);
                Console.WriteLine();
                TryGetMaxSalary(TestingDepartment.Instance);
                Console.WriteLine();

                TryGetMaxSalary(listOfDepartments);
                Thread.Sleep(100);
                Console.WriteLine();
                });
                Task.WaitAll(task1, task2, task3, task4, task5);
                Console.WriteLine("All tasks complete!");
            }
            {
                lock (locker)

                Console.WriteLine($"The Company is spending monthly {EmployeeManagementSystem.Instance.GetTotalCost():N0} lei on salaries");
                TryToGetCostForDepartment(TestingDepartment.Instance);
                TryToGetCostForDepartment(HumanResourcesDepartment.Instance);
                TryToGetCostForDepartment(LogisticsDepartment.Instance);
                Console.WriteLine();
            }
            {
                lock (locker)

                Console.WriteLine("These might be the best paid employees");
                TryGetNoOfWellPayedEmployees(6_000d);
                Console.WriteLine();
            }
        }

        private static object locker = new object();

        #region Methods
        static void TryToAddEmployee(Employee newEmployee)
        {
            try
            {
                lock (locker)
                    EmployeeManagementSystem.Instance.AddEmployee(newEmployee);
                Console.WriteLine($"Employee {newEmployee.Name} with ID: {newEmployee.ID} added");
            }
            catch (EmployeeAlreadyExistsException e)
            {
                Console.WriteLine(e.Message, newEmployee.Name, newEmployee.ID);
            }
        }

        static void TryToRemoveLazyEmployee(Guid employeeID)
        {
            lock (locker)
                try
                {
                    EmployeeManagementSystem.Instance.RemoveEmployee(employeeID);
                    Console.WriteLine($"Employee with ID: {employeeID} removed");
                }
                catch (EmployeeDoesNotExistException e)
                {
                    Console.WriteLine(e.Message, employeeID);
                }
        }

        static void TryGetNoOfWellPayedEmployees(double minimumSalary)
        {
            lock (locker)
                try
                {
                    EmployeeManagementSystem.Instance.GetNoOfWellPayedEmployees(minimumSalary).ForEach(e => Console.WriteLine(e));
                }
                catch (NoWellPaidEmployeesExistInCompanyException e)
                {
                    Console.WriteLine(e.Message);
                }
        }

        static void TryGetEmployeesByDepartment(IDepartment department)
        {
            lock (locker)
                try
                {
                    EmployeeManagementSystem.Instance.GetEmployeesByDepartment(department).ForEach(e => Console.WriteLine(e));
                }
                catch (NoEmployeesExistInDepartmentException e)
                {
                    Console.WriteLine(e.Message, department);
                }
        }

        static void TryGetMaxSalary()
        {
            lock (locker)
                try
                {
                    List<Employee> bestPaidEmployee = EmployeeManagementSystem.Instance.GetMaxSalary();

                    Console.WriteLine("Best paid employees in company are:");
                    bestPaidEmployee.ForEach(e => Console.WriteLine($"{e.Name} with ID: {e.ID} with a salary of {e.Salary}"));
                }
                catch (NoEmployeesExistInCompanyException e)
                {
                    Console.WriteLine(e.Message);
                }
        }

        static void TryGetMaxSalary(IDepartment department)
        {
            {
                lock (locker)

                    try
                    {
                        List<Employee> bestPaidEmployee = EmployeeManagementSystem.Instance.GetMaxSalary(department);

                        Console.WriteLine($"Best paid employees in {department}");
                        bestPaidEmployee.ForEach(e => Console.WriteLine($"{e.Name} with ID: {e.ID} with a salary of {e.Salary}"));
                    }
                    catch (NoEmployeesExistInCompanyException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    catch (NoEmployeesExistInDepartmentException e)
                    {
                        Console.WriteLine(e.Message, department);
                    }
            }
        }

        static void TryGetMaxSalary(List<IDepartment> departments)
        {
            lock (locker)
            {
                departments.ForEach(d => TryGetMaxSalary(d));
            }
        }

        static void TryToGetCostForDepartment(IDepartment department)
        {
            {
                lock (locker)

                    try
                    {
                        double salaries = EmployeeManagementSystem.Instance.GetCostForDepartment(department);

                        Console.WriteLine($"The {department} is spending monthly {salaries:N0} lei on salaries");

                    }
                    catch (NoEmployeesExistInDepartmentException e)
                    {
                        Console.WriteLine(e.Message, department);
                    }
            }
        }

        static void TryIncreasingSalary(Guid employeeID, double increasePercentage)
        {
            {
                lock (locker)
                    try
                    {
                        EmployeeManagementSystem.Instance.IncreaseSalary(employeeID, increasePercentage);
                        Console.WriteLine($"Employee with ID {employeeID} has got a {increasePercentage:N2}% raise");
                    }
                    catch (EmployeeDoesNotExistException e)
                    {
                        Console.WriteLine(e.Message, employeeID);
                    }
            }
        }

        static void TryIncreasingSalary(IDepartment department, double increasePercentage)
        {
            {
                lock (locker)

                    try
                    {
                        EmployeeManagementSystem.Instance.IncreaseSalary(department, increasePercentage);
                        Console.WriteLine($"The {department} has got a {increasePercentage:N2}% raise");
                    }
                    catch (NoEmployeesExistInDepartmentException e)
                    {
                        Console.WriteLine(e.Message, department);
                    }
            }
        }

        static void TryIncreasingSalary(List<IDepartment> departments, double increasePercentage)
        {
            lock (locker)

            {
                departments.ForEach(d => TryIncreasingSalary(d, increasePercentage));
            }
        }
    }
}
        #endregion
    





