# AspNetCore
This is Asp.Net Core Web Api project.

To test make sure you installed **xunit** extension and **xunitrunnervisualstudio**.
Architecture consist of main model *ListOfTasks* which is a container for *MyTask* and *name*.
All logic is in the *TaskService* class, available basic method to work with lists of *MyTask* and *ListOfTasks*. 
Available custom comparers *Alphabetically*, *Completed flag*, *Importance (low => normal => high)*, *Date*.