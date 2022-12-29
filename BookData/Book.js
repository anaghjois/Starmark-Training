const express=require("express")();
const bodyParser=require("body-parser");
const server=require("mssql/msnodesqlv8")
express.use(bodyParser.urlencoded({"extended":true}))
express.use(bodyParser.json())
const config={
    server:'192.168.171.36',
    database:'3302',
    driver:'msnodesqlv8',
    options:{
    trustedConnection:true,
    trustedCertificate:true
    }
}
const pool=new server.ConnectionPool(config)

//Get Data
express.get("/",(req,res)=>{
    pool.connect().then(()=>{
        pool.request().query("SELECT * FROM tblBook",(err,results)=>{
            if(err)
                console.error(err);
            else
                res.send(results.recordset)
        })
    }).catch((err)=>{
        if(err)console.error(err);
    })
})
//show data
express.get("/getAllBooks", function(req,res){
    res.sendFile(__dirname+"/getAllBooks.html")
})

express.get("/home", function(req,res){
    res.sendFile(__dirname+"/home.html")
})

express.get("/addbooks", function(req,res){
    res.sendFile(__dirname+"/addbooks.html")
})

express.get("/findbook", function(req,res){
    res.sendFile(__dirname+"/findbook.html")
})

//Delete Book
express.get("/delete/:id", function(req,res){
    const id = req.params.id
    console.log(id)

    const query = `delete from tblBook where BookId = ${id}`

    pool.connect().then(()=>{
        pool.request().query(query, function(err,result){
            if(err) console.error(err)

            else{
                res.sendFile(__dirname+"/getAllBooks.html")
            }
        })
    }).catch((err)=>{
        console.error(err)
    })
})
//Find Book by id
express.get("/:id", function(req,res){
    const id = req.params.id
    console.log(id)

    const query = `select * from tblBook where BookId = ${id}`

    pool.connect().then(()=>{
        pool.request().query(query, function(err,result){
            if(err) console.error(err)

            else{
                res.send(result.recordset)
            }
        })
    }).catch((err)=>{
        console.error(err)
    })
})
//Add Book
express.post("/afterAddBook", function(req,res){
    console.log(req.body)
    const query=`INSERT INTO tblBook VALUES(${req.body.BookId},'${req.body.BookName}','${req.body.AuthorName}',${req.body.Price})`

    pool.connect().then(()=>{
        pool.request().query(query, function(err,result){
            if(err) console.error(err)

            else{
               // res.send("Book added successfully")
                res.sendFile(__dirname+"/home.html")
            }
        })
    }).catch((err)=>{
        console.error(err)
    })
})
express.listen(1234, function(){
    console.log("Server is running!!! http://localhost:1234/")
})

