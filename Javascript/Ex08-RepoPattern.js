class Employee{
    constructor(id,name,address,salary){
        this.id=id
        this.name=name
        this.address=address
        this.salary=salary
    }
}

class Emprepo{
     data=[]
     addEmployee(emp){
        this.data.push(emp)
     }
     getAllEmployees(){
        return this.data
    }
     deleteEmployee(id){

    
     }
     getEmployee(id){
        for (const emp of this.data) {
            if(emp.id==id)
                return emp;
        }
        throw`Employee by ID ${id} not found`
     }
     updateData(newEmp){
        for (const Emp of this.data) {
            if(newEmp.id==Emp.id){
                Emp.address = newEmp.address; 
                Emp.salary= newEmp.salary; 
                Emp.name=newEmp.name;
                return;
            }
        }
        throw"Employee Data not found"
        }
     }







///////////TESTING////////////

let a=new Emprepo();
const data=a.getAllEmployees()
for (const emp of data) {
    console.log(emp.name,emp.id)
}