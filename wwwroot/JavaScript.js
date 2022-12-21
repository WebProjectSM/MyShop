
    async function logIn(){
        const pass = document.getElementById("password").value;
        const name = document.getElementById("name").value;
        const res = await fetch(`https://localhost:44380/api/Home/?name=${name}&password=${pass}`);
        
            
        if (!res.ok)
            throw Error(`your connect is fail ${res.status} ,try again`);
        return;
        if (res.status == 204)
            alert("you are not exist, for sigin press new user");
        else {
       

            const user = await res.json();
            if (user) {
                sessionStorage.setItem('currentUser', JSON.stringify(user));
                /*setValues();*/
                window.location.href = "update.html";
            }
       
             
          

            
        }
} 
async function singIn() {


    const user = {
        "Id": 0,
        "Password": document.getElementById("password").value,
        "Email": document.getElementById("mail").value,
        "Phone": document.getElementById("phone").value,
        "FirstName": document.getElementById("fname").value,
        "LastName": document.getElementById("lname").value
    }


    const res = await fetch("https://localhost:44380/api/Home", {

        headers: { "content-Type": "application/json" },
        method: 'POST',
        body: JSON.stringify(user)
    });

    if (!res.ok)
        throw Error(`your connect is fail ${res.status} ,try again`);


    const data = await res.json;
    sessionStorage.setItem('currentUser', JSON.stringify(data));
   /* setValues()*/;
    window.location.href = "update.html";
}

    function setValues() {
        const tmpUser = sessionStorage.getItem('currentUser');
        const user = JSON.parse(tmpUser);


        console.log(user['userName']);
        const userName = user["userName"] ;
        const userCod = user["cod"];
        const userMail = user["mail"];
        const userPhone = user["phone"];
        const userFname = user["firstName"];
        const userLname = user["lastName"];

        let div = document.getElementById("up")
        div.style.visibility = "visible";
        document.getElementById("title").innerHTML = `שלום ${userName}`;
        let a = document.getElementById("un");
        a.setAttribute("value", userName);
        let b = document.getElementById("fn");
        b.setAttribute("value", userFname);
        let c = document.getElementById("ln");
        c.setAttribute("value", userLname);
        let d = document.getElementById("email");
        d.setAttribute("value", userMail);
        let e = document.getElementById("pass");
        e.setAttribute("value", userCod);
        let f = document.getElementById("ph");
        f.setAttribute("value", userPhone);
        



     /*   getUserName.setAttribute('value', userName);*/
      

      

            //"Cod": document.getElementById("password").value,
            //    "Mail": document.getElementById("mail").value,
            //        "Phone": document.getElementById("phone").value,

            //            "FirstName" : document.getElementById("fname").value,
            //                "LastName" : document.getElementById("lname").value


    }



async function update() {
    const tmpId = sessionStorage.getItem('currentUser');
    const id = JSON.parse(tmpId);
    const realId = id["id"];


    const user = {
        "Id": realId,
         "Password": document.getElementById("pass").value,
        "Email": document.getElementById("email").value,
        "Phone": document.getElementById("ph").value,

        "FirstName": document.getElementById("fn").value,
        "LastName": document.getElementById("ln").value
    }


    const res = await fetch(`https://localhost:44380/Api/Home/${realId}`, {

        headers: { "content-Type": "application/json" },
        method: 'PUT',
        body: JSON.stringify(user)
    });

    if (res.ok) {
        alert("your details were update")
    }
    

}
async function  check (){
 password = document.getElementById("password").value;
    const res = await fetch("https://localhost:44387/api/checkPassword", {
        headers: { "Content-Type": "application/json; charset=utf-8" },
        method: 'POST',
        body: JSON.stringify(password)
    })
    if (res > 0)
        alert(res);

    }