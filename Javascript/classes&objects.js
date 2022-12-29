let obj={};
obj.id=1;
obj.name="Idris";
obj.address="Arsikere";
obj.salary=10000;

for (const key in obj) {
    console.log(obj[key]);
}

function disp(){
    return JSON.stringify(obj);
}

class Employee{
    constructor(id,name,address,salary){
        this.id=id
        this.name=name
        this.address=address
        this.salary=salary
    }
}

const emp=new Employee(111,"Malli","Shimoga",50000)
