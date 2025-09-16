# 🎓 Student Management System (C# OOP Project)

## 📌 Project Purpose
This project is built to demonstrate **Object-Oriented Programming (OOP)** concepts in C#.  
It manages **Students, Teachers, Courses, and Departments** using a clean OOP design and repository pattern.  

The main goal is to show:
- Abstraction
- Inheritance
- Polymorphism
- Encapsulation
- Repository Design Pattern  

---

## 🚀 Features
- Add / Remove / Show Students  
- Add / Remove / Show Teachers  
- Add / Remove / Show Courses  
- Add / Remove / Show Departments  
- Data stored in memory (List-based Repository)  
- Clear menu-based navigation in Console  

---

## 🏗️ Project Structure

Classes:
- **Person** → Abstract base class  
- **Student** → Inherits Person, linked with Course  
- **Teacher** → Inherits Person, linked with Course  
- **Course** → Linked with Department  
- **Department** → Independent entity  
- **Repositories** → Handle CRUD for each entity  

---

## 🧩 OOP Concepts in This Project
1. **Abstraction**  
   - Implemented using the `Person` abstract class.  
   - Hides common details of Student & Teacher, only exposes necessary methods like `DisplayInfo()`.  

2. **Inheritance**  
   - `Student` and `Teacher` inherit from `Person`.  
   - Reuse of properties (`Name`, `Age`, `Email`) without rewriting code.  

3. **Polymorphism**  
   - Overridden `DisplayInfo()` method in both `Student` and `Teacher`.  
   - Same method behaves differently for each class.  

4. **Encapsulation**  
   - Properties (`Name`, `Age`, `Email`, etc.) are wrapped with `get; set;`.  
   - Data access is controlled, not directly exposed.  

5. **Repository Pattern**  
   - Separate repository classes: `StudentRepository`, `TeacherRepository`, etc.  
   - Provides clean **CRUD** operations (Add, Remove, Display).  

---

## 🔄 Flow of the Program
1. User opens Console Menu.  
2. Chooses option (Add Student, Add Teacher, Show Courses, etc.).  
3. Input data → Stored in respective Repository (List).  
4. When "Show" is selected:
   - If data exists → Display details.  
   - If empty → Show ⚠️ "No Data Till Now".  

---

## 📊 Flowchart


---

## 🖥️ How to Run
1. Open project folder in **Visual Studio** or **VS Code**.  
2. Create a new C# Console Application project.  
3. Copy the code from `StudentManagementSystem.cs`.  
4. Build & Run.  
5. Use menu options to test features.  

---

## 🌟 Example Output
<img width="146" height="172" alt="image" src="https://github.com/user-attachments/assets/4b3f1276-8b79-426e-8650-8d7d4b6f27c3" />
<img width="162" height="178" alt="image" src="https://github.com/user-attachments/assets/4c0bc7f9-da03-4510-afd2-1ae07b4a9a21" />
<img width="159" height="191" alt="image" src="https://github.com/user-attachments/assets/37c4829a-e915-4c47-a939-b465d4b6e376" />

---

## 📌 Future Improvements
- Add database integration (SQL Server / EF Core).  
- Add file saving (JSON/CSV).  
- Build a web-based UI using ASP.NET MVC.  

---

## 👨‍💻 Author
Developed by **[Bhagyasree Sarker]** as part of OOP practice project in C#.
