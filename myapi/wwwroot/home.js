 
async function getRespone() {
   const postData =
    {
       userName: document.querySelector(".userName").value,
       password: document.querySelector(".password").value,
       firstName: document.querySelector(".firstName").value,
       lastName: document.querySelector(".lastName").value,
       
    };
    const responsePost = await fetch('api/users', {
        method: 'POST',
        headers: {
            'Content-Type': 'application / json'
        },
        body:JSON.stringify(postData)
    });
    const dataPost = await responsePost.json();
    console.log('POST data', dataPost);
    
    if (!responsePost.ok)
        throw new Error(`error!! status: ${responsePost.status}`);
    
    alert(dataPost);
}

const loginUser = async () => {
  
    const userlogin = {
        userName: document.querySelector(".userName").value,
        password: document.querySelector(".password").value
    }
         const responsePostLogin = await fetch('api/users/login', {
             method: 'POST',
             headers: {
                 'Content-Type': 'application / json'
             },
             body: JSON.stringify(userlogin)
         });
       
        //console.log('POSTLOGIN data', dataPost1);
   
        //if(!responsePostLogin.ok())
        //throw new Error(`error!! status: ${responsePostLogin.status}`);
        
    const user = await responsePostLogin.json();
    sessionStorage.setItem('currentUser', user.id)
    alert(JSON.stringify(user))

}
const put = async () => {   
    const postData =
    {
        userName: document.querySelector(".userName").value,
        password: document.querySelector(".password").value,
        firstName: document.querySelector(".firstName").value,
        lastName: document.querySelector(".lastName").value,
        id: sessionStorage.getItem('currentUser')
    };
   const userJson = sessionStorage.getItem('currentUser');
    
    const updateUser = await fetch('api/users', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application / json'
        },
        body: JSON.stringify(postData)
    });
    if (!updateUser.ok)
        throw new Error(`error!! status: ${updateUser.status}`);
    else
    alert("updates!")
}
