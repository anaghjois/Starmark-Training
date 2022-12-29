const data=new Map()
function addVehicle(type){
    if(data.has(type)){
        let count=data.get(type)
        count+=1
        data.set(type,count)
    }else{
        data.set(type,1)
    }
}
function getdetails(type){
    let amt=0;
    const count=data.get(type)
    switch (type) {
        case "Car":amt=count*60
            break;
        case "Bike":amt=count*40
            break;
        case "Truck":amt=count*100
            break;    
        default:
            break;
    }
    return amt;
}