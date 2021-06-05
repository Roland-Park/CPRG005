# CPRG005 Final Assignment

June 5 2021 TODO:
- Form validation
- secure api endpoints and add token to request headers
- proofreading and testing

______________________________________________________________________________
Purpose: handle marina leasing services
Stack: dotnet5, razor pages. entity framework

## Requirements

### Public Pages:
- Home page
- Available slips, by location and dock. publicly available
- Contact Us page with location, addresses, and phone #s. publicly available
- Registration page
- Login page

### Pages Requiring Authentication
- Lease slip page: diplay existing leases and create new ones
- Register boat page: register new boat(s) and update existing
- User page to update personal info

### Web Service Requirements
AddCustomer: The first name, last name, phone number and city will be passed
into this method and the record inserted. A string result is returned containing the
newly created identity id or an error message.

• UpdateCustomer: The same information along with id is passed in and the
customer record updated by the id number. A string result is returned containing
“Success” or an error message.

• GetCustomerRecordById: A customer record is returned when the id value is
passed in.

• GetAllCustomers: A DataSet or Array containing all customers is returned.

• AddBoat: The boat registration number, manufacturer name, model year, length
and id of the owner will be passed in and the record inserted. A string result is
returned containing “Success” or an error message.

• UpdateBoat: An existing boat record is updated when all information including
boat id is passed in. A string result is returned containing “Success” or an error
message.

• GetBoatsByCustomerId: A DataSet or Array containing all boats registered by a
specific customer.

• AddAuthorize: The auth user name, password and customer id are passed into
the method and a new record is inserted. A string result is returned containing
“Success” or an error message.

• UpdateAuthorize: This method updates an existing authorize record. A string
result is returned containing “Success” or an error message.

• AddLease: Lease start date, end date, slip id, customer id and lease type id will
be passed into the method. A record will be inserted and a string result is
returned containing “Success” or an error message.

• GetLocations: a DataSet or Array of all locations is returned
GetDocks: A DataSet or Array of all locations is returned.

• GetAvailableSlipsByDockId: A DataSet or Array of all available slips is returned
when a dock id is passed in.

• GetLeaseTypes: A DataSet or Array of all lease types is returned.

• Authenticate: The user name and password are passed into the method; null is
returned if there is no record or else the Authorize object containing the nested
Customer object is returned.
