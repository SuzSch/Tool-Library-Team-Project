# Stuff Swap: A Tool Library

**Description:** A sharing community right here in Portland, Oregon! Stuff Swap is web application for a tool, equipment, and hobby supply sharing for individuals in Portland, OR and surrounding areas. It has no physical warehouse and doesn't need to be staffed, making it accessible to anyone at any time.
**Features** 
    - **User egistration:** Users can register for an account and complete a profile. 
    - **Tool listing:** Users can list tools they have available to lend to other community members. 
    - **Tool borrowing:** Users can seamlessly select and borrow items.

## Technologies used

- C#
- .Net
- mySql WorkBench

## Setup and installation requirements

- Clone this repository to your desktop.
- Navigate into your _StuffSwapClient_ and create a new file name _appsettings.json_ to be placed in root directory of the `StuffSwapClient`.
- Update the contents of your _appsettings.json_ file with the following:

```
{
    "AllowedHosts": "*",
    "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=[NAME-OF-DATABASE];uid=[YOUR-USERNAME];pwd=[YOUR-PASSWORD];"
    },
    "Jwt":{
        "Issuer": "Issuer",
        "Audience": "Audience",
        "Key": [Your Personal Passkey]
    }
  }
```

- Confirm you have `mySql WorkBench` installed, if you don't follow the installation instructions found [here](https://dev.mysql.com/doc/workbench/en/wb-installing.html).
- Then in your terminal run the following command: `dotnet ef database update`

## API Documentation

**Description:** Welcome to the StuffSwapAPI. This API provides endpoints to manage tools and users within the tools database. A user can access, create, update, and delete tools.

### Testing Endpoints

**Postman**

- Open your terminal and navigate to the _StuffSwapApi_
- In your terminal, run the command: `dotnet run`
- Once your server is running, to test your endpoints, launch postman. If you don't have postman installed, follow installation instructions found [here](https://www.postman.com/downloads/).

**Swagger UI**

- An alternative to testing endpoints with postman is using `Swagger UI`
- Open your terminal and navigate to the _StuffSwapApi_
- In your terminal, run the following command: `dotnet watch run`.

### Endpoint

#### Tools

1. **Get: /api/Tools**

   - **Description:** Retrieves a list of all tools in the database.
     `"http://localhost:5000/api/Tools"`

2. **Post: /api/Tools**

   - **Description:** Create a new tool.
     `"http://localhost:5000/api/Tools"`
   - **Request Body:** `Tool` object with required fields.
   - **Returns:**
     - 201 Created: If the tool is successfully created and added to the database. When testing in postman, it returns the created object in the response body.
     - 400 Bad Request: If the provided tool object is invalid.

3. **Get: /api/Tools/{id}**

   - **Description:** Retrieves a specific tool by its Id.
     `"http://localhost:5000/api/Tools/{id}"`
   - **Path Parameter:**
   - `id` (int): Id of the tool to retrieve.
   - **Returns:**
   - 200 Okay with `Tool` object: If the tool is found.
   - 404 Not Found: If the tool with the given Id does not exist.

4. **Put: /api/Tools/{id}**

   - **Description:** Update an existing tool.
     - _User can update one or multiple properties of selected tool_
       `"http://localhost:5000/api/Tools/{id}"`
   - **Path Parameters:**
     - `id` (int): Id of the tool to update.
   - **Request Body:** `Tool` object with updated fields.
   - **Returns:**
     - 204 No content: If the update is successful
     - 400 Bad Request: If the provided Id does not match the tool id.
     - 404 Not Found: If the tool with the given Id does not exist.

5. **Delete: /api/Tools/{id}**

   - **Description:** Delete a tool using its id.
     `"http://localhost:5000/api/Tools/{id}"`
   - **Path Parameters:**
     - `id` (int): Id of the tool to delete
   - **Returns:**
     - 204 No content: If the tool is successfully deleted.
     - 404 Not found: If the tool with the given Id does not exist.

6. **Post: /api/Tools/{id}/AddUserBorrower**

   - **Description:** Allow users to borrow a tool by associating a borrower with a specific tool.
     `"http://localhost:5000/api/Tools/{id}/AddUserBorrower"`
   - **Path Parameters:**
     - `id` (int): Id of the tool to be borrowed.
   - **Request Body:**
     - `appUserId` (int): The Id of the user who will borrow the tool.
   - **Returns:**
     - 204 No content: If the borrower is successfully associated with the tool. The tool will be marked as unavailble for borrowing.
     - 400 Bad Request: If the tool is already borrowed or the provided input is invalid.

7. **Delete /api/Tools/{id}/RemoveUserBorrower**
   - **Description:** Remove the association between the borrower and the tool.
     `"http://localhost:5000/api/Tools/{id}/RemoveUserBorrower"`
   - **Path Parameters:**
     - `id` (int): Id of the tool that was borrowed.
   - **Returns:**
     - 204 No Content: If the association between a borrower and a tool was successfully removed.
     - 400 Bad Request: If the borrower is not associated with the tool.

#### AppUser

1. **Post: /GetToken**
   - **Description:** Allows the user to obtain a JWT by providing valid user credentials.
     `"http://localhost:5000/GetToken"`
   - **Request Body:**
     - `userName` (string): user's valid username
     - `userPassword` (string): user's valid password.
   - **Returns:**
     - 200 Ok: If provided user credentials match, it returns a jwt token.
     - 401 Unauthorized: If user provided invalid or missing credentials.

## Contributors

- [Natalie Benjes](https://github.com/nataliebenjes)
- [Michael Carroll](https://github.com/mcarroll138)
- [Jason E. Church](https://github.com/elijahchurch)
- [Elle Hailu](https://github.com/ellehailu)
- [Daniel Kiss](https://github.com/dan-kiss-dev-this)
- [Suzanne Schuber](https://github.com/SuzSch)

## License

MIT [![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

Copyright (c) _2023_ _StuffSwapAPI_

_Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:_

_The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software._

_THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE._
