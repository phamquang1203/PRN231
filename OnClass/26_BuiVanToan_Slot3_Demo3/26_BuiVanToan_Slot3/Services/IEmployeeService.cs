﻿using _26_BuiVanToan_Slot3.Models;
using _26_BuiVanToan_Slot3.ViewModels;

namespace _26_BuiVanToan_Slot3.Services
{
   public interface IEmployeeService 
	{ 
	/// <summary> 
	/// get list of all employees 
	/// </summary> 
	/// <returns></returns> 
	List<Employees> GetEmployeesList();
    /// <summary> 
    /// get employee details by employee id 
    /// </summary> 
    /// <param name="empId"></param> 
    /// <returns></returns> 
    Employees GetEmployeeDetailsById(int empId);
    /// <summary> 
    ///  add edit employee 
    /// </summary> 
    /// <param name="employeeModel"></param> 
    /// <returns></returns> 
    ResponseModel SaveEmployee(Employees employeeModel);

 

	/// <summary> 
	/// delete employees 
	/// </summary> 
	/// <param name="employeeId"></param> 
	/// <returns></returns> 
	ResponseModel DeleteEmployee(int employeeId);
} 

}
