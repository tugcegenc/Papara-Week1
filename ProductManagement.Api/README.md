# Product Management API

This project is a **RESTful API** developed using .NET Core. The API includes basic CRUD (Create, Read, Update, Delete) operations for managing products, along with additional listing and filtering functionalities.

## 🚀 **Setup and Run**

### **1. Requirements**
- .NET SDK (7.0+)
- A REST client (Postman, Insomnia, or cURL)

### **2. Clone the Project**
```bash
git clone https://github.com/username/product-management-api.git
cd product-management-api
```

### **3. Run the Project**
```bash
dotnet run
```

By default, the API runs on **http://localhost:5000**.

---

## 📌 **API Endpoints**

### **1️⃣ Get All Products**
```http
GET /api/products
```
#### **Optional Filtering & Sorting**
| Parameter | Type | Description |
|-----------|------|-------------|
| name | string | Filter by product name |
| sortBy | string | Accepts "price" or "name" for sorting |

**Example Usage:**
```http
GET /api/products?name=Laptop&sortBy=price
```

---

### **2️⃣ Get Product by ID**
```http
GET /api/products/{id}
```
**Example:**
```http
GET /api/products/1
```

---

### **3️⃣ Add a New Product**
```http
POST /api/products
Content-Type: application/json
```
#### **Body:**
```json
{
  "name": "Tablet",
  "description": "10 inch Tablet",
  "price": 1200,
  "stock": 15,
  "isAvailable": true
}
```
#### **Success Response:**
- **201 Created** (Product successfully added.)

---

### **4️⃣ Update a Product**
```http
PUT /api/products/{id}
Content-Type: application/json
```
#### **Body:**
```json
{
  "name": "Gaming Laptop",
  "description": "16GB RAM, RTX 3070",
  "price": 2500,
  "stock": 5,
  "isAvailable": true
}
```
#### **Success Response:**
- **204 No Content** (Successfully updated.)

---

### **5️⃣ Delete a Product**
```http
DELETE /api/products/{id}
```
#### **Success Response:**
- **204 No Content** (Product successfully deleted.)

---

## 🛠 **Technologies**
- **.NET Core 7.0+**
- **ASP.NET Core Web API**
- **C#**
- **Swagger (Optional)**

---

## 📜 **License**
This project is licensed under the **MIT License**.

**📌 Additions:** If you want to integrate Swagger, you can use the `Swashbuckle.AspNetCore` library. Additionally, you can enhance the project by adding a **global exception handler** and **unit tests**. 🚀

