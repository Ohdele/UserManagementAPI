"# Activity 1: Setup and Testing"


**Postman Collection Setup for User Management API Testing**

**Important Note:** The reviewer *must* restart the application (`dotnet run`) before each full test run to ensure consistent results. This is because user data is stored in memory and is cleared on restart.

**Collection:** Create a new Collection in Postman named "User Management API".

**Requests (Add these requests within the "User Management API" Collection):**

**1. GET all users (Empty Array):**

*   **Request Type:** GET
*   **URL:** `http://localhost:5176/User`
*   **Expected Output:**
    *   Status Code: 200 OK
    *   Response Body: `[]`

**2. POST a new user (John Doe):**

*   **Request Type:** POST
*   **URL:** `http://localhost:5176/User`
*   **Body (raw JSON):**

    ```json
    {
        "name": "John Doe",
        "email": "john.doe@example.com"
    }
    ```

*   **Expected Output:**
    *   Status Code: 201 Created
    *   Response Body (example): `{"id": 1, "name": "John Doe", "email": "john.doe@example.com"}` (The `id` might be different on subsequent runs after restarts)

**3. GET the created user by ID (John Doe):**

*   **Request Type:** GET
*   **URL:** `http://localhost:5176/User/1` (Use the `id` from the previous POST response)

*   **Expected Output:**
    *   Status Code: 200 OK
    *   Response Body (example): `{"id": 1, "name": "John Doe", "email": "john.doe@example.com"}`

**4. POST another user (Jane Doe):**

*   **Request Type:** POST
*   **URL:** `http://localhost:5176/User`
*   **Body (raw JSON):**

    ```json
    {
        "name": "Jane Doe",
        "email": "jane.doe@example.com"
    }
    ```

*   **Expected Output:**
    *   Status Code: 201 Created
    *   Response Body (example): `{"id": 2, "name": "Jane Doe", "email": "jane.doe@example.com"}`

**5. GET all users (Both Users):**

*   **Request Type:** GET
*   **URL:** `http://localhost:5176/User`
*   **Expected Output:**
    *   Status Code: 200 OK
    *   Response Body (example): `[{"id": 1, "name": "John Doe", "email": "john.doe@example.com"}, {"id": 2, "name": "Jane Doe", "email": "jane.doe@example.com"}]`

**6. PUT update an existing user (John Doe):**

*   **Request Type:** PUT
*   **URL:** `http://localhost:5176/User/1`
*   **Body (raw JSON):**

    ```json
    {
        "name": "Updated John",
        "email": "updated.john@example.com"
    }
    ```

*   **Expected Output:**
    *   Status Code: 204 No Content (No response body)

**7. GET the updated user (Updated John):**

*   **Request Type:** GET
*   **URL:** `http://localhost:5176/User/1`
*   **Expected Output:**
    *   Status Code: 200 OK
    *   Response Body (example): `{"id": 1, "name": "Updated John", "email": "updated.john@example.com"}`

**8. DELETE a user (John Doe):**

*   **Request Type:** DELETE
*   **URL:** `http://localhost:5176/User/1`
*   **Expected Output:**
    *   Status Code: 204 No Content (No response body)

**9. GET all users after delete (Jane Doe):**

*   **Request Type:** GET
*   **URL:** `http://localhost:5176/User`
*   **Expected Output:**
    *   Status Code: 200 OK
    *   Response Body (example): `[{"id": 2, "name": "Jane Doe", "email": "jane.doe@example.com"}]`

