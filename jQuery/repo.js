class Expenses{
    static no=0
    constructor(details,amount,date){
        this.id=++this.constructor.no
        this.details=details
        this.amount=amount
        this.date=date
    }
}
class ExpenseManager{
    expenses=[]
    addNewExpense=(expense)=>this.expenses.push(expense);
    findExpense=(details)=>this.expenses.filter((e)=>e.details.includes(details));
    getAllExpnses=()=>this.expenses
    getExpenseById=(id)=>this.expenses.find((e)=>e.id==id)
    findExpenseByDate=(date)=>this.expenses.filter((e)=>e.date.toDateString()==date.toDateString());
    modifyExpense=(id,expense)=>{
        let foundIndex=this.expenses.findIndex(ex=>ex.id==id);
        if(foundIndex==-1)throw"Expense not found to update";
        this.expenses.splice(foundIndex,1,expense)
    }
}


//TESTING
// let obj=new ExpenseManager()
// obj.addNewExpense(new Expenses("Food at cafe",1555,new Date(2022,9,12)))
// obj.addNewExpense(new Expenses("Brunch at cafe",120,new Date(2022,10,23)))
// obj.addNewExpense(new Expenses("coffee at cafe",1555,new Date(2022,11,11)))
// obj.addNewExpense(new Expenses("tea at cafe",1555,new Date(2022,11,12)))
// let data=obj.getAllExpnses()
// console.log(obj.getAllExpnses())
// console.log(obj.findExpenseByDate(new Date(2022,10,23)))
// for(const ex of data){
//     console.log(ex.id)
// }
// console.log("searching details")
// data=obj.findExpense("tea at cafe")
// for(const ex of data){
//     console.log(ex.id)
// }
// console.log("searching on date")
// data=obj.findExpenseByDate(new Date(2022,9,12))
// for (const ex of data) {
//     console.log(ex.id)
// }
// const ex=obj.getExpenseById(2)
// ex.details="modified with new info"
// obj.modifyExpense(3,ex)
// console.log(ex.details)
// // data=obj.getAllExpnses();
// // for(const ex of data){
// // console.log(ex.details)
// //}
// prajith=obj.getAllExpnses();
// for (const w of prajith) {
//     console.log(w)
// }
