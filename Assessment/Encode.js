const inputArray=[]
const output=[]
const text="the quick brown fox jumps over the lazy dog"
const txtarray=text.split(" ")
let output1="bangalore"
let result=""
for(let i=0;i<output1.length;i++){
    output[i]=output1[i]
}
console.log(output)
console.log(txtarray)
for(let i=0;i<output.length;i++)
{
    //console.log(output)
    for(let j=0;j<txtarray.length;j++)
    {
        for (let k = 0; k < txtarray.length; k++) {
        //console.log(txtarray[j].charAt(k))
        // if(txtarray[k]==" ") result+='-'
        if(txtarray[k].charAt(j)==output[i]){
            result=""+k+j
            //const a=i
            //const b=k
            //console.log(a)
            //console.log(b)
            console.log(result)
            break
         }
    }
}
}
