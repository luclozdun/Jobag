using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobag.src.Enterprise.Domain.Model.Aggregates;
using Jobag.src.Enterprise.Domain.Model.ValueObjects;
using Jobag.src.Enterprise.Domain.Repository;
using Jobag.src.Membership.Domain.Model.ValueObject;
using Jobag.src.Membership.Domain.Repository;
using Jobag.src.Membership.Domain.Result;
using Jobag.src.Shared.Domain.Model.Entities;

namespace Jobag.src.Membership.Domain.Model.Entities
{
    public class OrderEmployee : Entity
    {
        public PlanEmployee PlanEmployee { get; private set; }
        public int PlanEmployeeId { get; private set; }
        public Employee Employee { get; private set; }
        public int EmployeeId { get; private set; }

        public double Price { get; private set; }

        public DateTime CreatedAt { get; private set; }

        private OrderEmployee(int planEmployeeId, int employeeId, PlanEmployee planEmployee, Employee employee)
        {
            PlanEmployeeId = planEmployeeId;
            EmployeeId = employeeId;
            Price = planEmployee.Price;
            CreatedAt = DateTime.Now;
            PlanEmployee = planEmployee;
            Employee = employee;
        }

        public static async Task<OrderEmployeeResult> Create(int _planId, int _employeeId, IEmployeeRepository employeeRepository, IPlanEmployeeRepository planRepository)
        {
            EmployeeId employeeId = new EmployeeId(_employeeId);
            PlanEmployeeId planId = new PlanEmployeeId(_planId);

            Employee employee = await employeeRepository.FindById(employeeId);
            if (employee == null)
                return new OrderEmployeeResult("Employee not found");

            PlanEmployee plan = await planRepository.FindById(planId);
            if (plan == null)
                return new OrderEmployeeResult("Plan not found");

            employee.AddPlan(plan);

            OrderEmployee order = new OrderEmployee(_planId, _employeeId, plan, employee);

            return new OrderEmployeeResult(order);
        }
    }
}