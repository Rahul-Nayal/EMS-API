namespace Backend.Permission
{
    public static class Permission
    {
        public static class Employee
        {
            public const string View = "Employee.View";
            public const string Create = "Employee.Create";
            public const string Update = "Employee.Update";
            public const string Delete = "Employee.Delete";


            public static class Attendance
            {
                public const string View = "Employee.Attendance.View";
                public const string Create = "Employee.Attendance.Create";
                public const string Update = "Employee.Attendance.Update";
                public const string Delete = "Employee.Attendance.Delete";
            }

            public static class Certificate
            {
                public const string View = "Employee.Certificate.View";
                public const string Create = "Employee.Certificate.Create";
                public const string Update = "Employee.Certificate.Update";
                public const string Delete = "Employee.Certificate.Delete";
            }

            public static class Education
            {
                public const string View = "Employee.Education.View";
                public const string Create = "Employee.Education.Create";
                public const string Update = "Employee.Education.Update";
                public const string Delete = "Employee.Education.Delete";
            }

            public static class WorkExperience
            {
                public const string View = "Employee.WorkExperience.View";
                public const string Create = "Employee.WorkExperience.Create";
                public const string Update = "Employee.WorkExperience.Update";
                public const string Delete = "Employee.WorkExperience.Delete";
            }

            public static class ContactDetails
            {
                public const string View = "Employee.ContactDetails.View";
                public const string Create = "Employee.ContactDetails.Create";
                public const string Update = "Employee.ContactDetails.Update";
                public const string Delete = "Employee.ContactDetails.Delete";
            }

            public static class FamilyDetail
            {
                public const string View = "Employee.FamilyDetail.View";
                public const string Create = "Employee.FamilyDetail.Create";
                public const string Update = "Employee.FamilyDetail.Update";
                public const string Delete = "Employee.FamilyDetail.Delete";
            }
            
        }

        public static class Department
        {
            public const string View = "Department.View";
            public const string Create = "Department.Create";
            public const string Update = "Department.Update";
            public const string Delete = "Department.Delete";
        }

        public static class JobRole
        {
            public const string View = "JobRole.View";
            public const string Create = "JobRole.Create";
            public const string Update = "JobRole.Update";
            public const string Delete = "JobRole.Delete";
        }

        public static class Asset
        {
            public const string View = "Asset.View";
            public const string Create = "Asset.Create";
            public const string Update = "Asset.Update";
            public const string Delete = "Asset.Delete";
        }

        public static class AssetType
        {
            public const string View = "AssetType.View";
            public const string Create = "AssetType.Create";
            public const string Update = "AssetType.Update";
            public const string Delete = "AssetType.Delete";
        }

        public static class LeaveType
        {
            public const string View = "LeaveType.View";
            public const string Create = "LeaveType.Create";
            public const string Update = "LeaveType.Update";
            public const string Delete = "LeaveType.Delete";
        }

        public static class Leave
        {
            public const string View = "Leave.View";
            public const string Create = "Leave.Create";
            public const string Update = "Leave.Update";
            public const string Delete = "Leave.Delete";
        }

        public static class LeaveBalance
        {
            public const string View = "LeaveBalance.View";
            public const string Create = "LeaveBalance.Create";
            public const string Update = "LeaveUpdate.Update";
            public const string Delete = "LeaveBalance.Delete";
        }

        public static class SalaryStructure
        {
            public const string View = "SalaryStructure.View";
            public const string Create = "SalaryStructure.Create";
            public const string Update = "SalaryStructure.Update";
            public const string Delete = "SalaryStructure.Delete";
        }

        public static class Payroll
        {
            public const string View = "Payroll.View";
            public const string Create = "Payroll.Create";
            public const string Update = "Payroll.Update";
            public const string Delete = "Payroll.Delete";
        }

        public static class Project
        {
            public const string View = "Project.View";
            public const string Create = "Project.Create";
            public const string Update = "Project.Update";
            public const string Delete = "Project.Delete";
        }

        public static class EmployeeProject
        {
            public const string View = "EmployeeProject.View";
            public const string Assign = "EmployeeProject.Assign";
            public const string Unassign = "EmployeeProject.Unassign";
            public const string UpdateRole = "EmployeeProject.UpdateRole";
        }
    }
}

//17