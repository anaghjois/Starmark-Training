class foodOrder{
    static foodId=0
    constructor(foodname,foodimg,quantity,amount){
        this.foodId=++this.constructor.foodId
        this.foodname=foodname
        this.foodimg=foodimg
        this.quantity=quantity
        this.amount=amount
    }
}
class hotel{
    FoodDetails=[]
    FoodCart=new Map()

    addFoodDetails=(FoodDetails)=>this.FoodDetails.push(FoodDetails)
    getFoodDetails=()=>this.FoodDetails
    addToFoodcart=(FoodDetails)=>this.FoodCart.set(FoodDetails.foodname,FoodDetails)
    viewCart=()=>this.FoodCart
    getFoodbyId=(id)=>this.FoodDetails.find((e)=>e.foodId==id)
}

const FoodRepo=new hotel()
FoodRepo.addFoodDetails(new foodOrder("Masala Dose","./Foods/6340448.jpg",1,60))
FoodRepo.addFoodDetails(new foodOrder("Idli Vada","./Foods/idli.jpg",1,40))
FoodRepo.addFoodDetails(new foodOrder("Fried Rice","./Foods/fried_rice.jpg",1,70))

console.log(FoodRepo.getFoodDetails())
console.log(FoodRepo.viewCart())