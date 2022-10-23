# TestAssignment3

## Guide
This is an assignment that meets the requirements for the 3rd assignemnt in our test course.
The only thing that has not been implemented is the Customer's phonenumbers. The technology is implemented in the system, so that it would be able to happen. I just haven't had the time. Migration is coupled up in the DbApplicationContext in the Context folder.

### Data Layer
This project holds the storage classes, which are the ones that are directly in contact with the database

#### Create BookingStorage and BookingStorageImpl with methods
- int createBooking(Booking booking)
- Collection<Booking> getBookingsForCustomer(int customerId)

#### Create EmployeeStorage and EmployeeStorageImpl with methods
- int createEmployee(Employee employee)
- Collection<Employee> getEmployeeWithId(int employeeId)

### Service Layer

#### Create BookingService and BookingServiceImpl with methods
- int createBooking(customerId, employeeId, date, start, end)
- Collection<Booking> getBookingsForCustomer(customerId)
- Collection<Booking> getBookingsForEmployee(employeeId)

#### Create EmployeeService and EmployeeServiceImpl with methods
- int createEmployee(employee)
- Employee getEmployeeById(employeeId)
