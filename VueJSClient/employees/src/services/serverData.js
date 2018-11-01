import Vue from 'vue';

var url = 'http://vuejswebapiserver.localhost.com/api/employee';

function getEmployees(){    
    return new Promise((resolve, reject) => {
            Vue.http.get(url).then((response) => {
            //var result = response.data;
            resolve(response);
            //return {error: false, data: result};
        }).catch((error) => {
            console.log(error);
            reject(error);
            //return {error: true, error: error};
        });
    });
}

function getEmployee(id){    
    return new Promise((resolve, reject) => {
            Vue.http.get(url + '/' + id).then((response) => {
            //var result = response.data;
            resolve(response);
        }).catch((error) => {
            console.log(error);
            reject(error);
        });
    });
}

function addEmployee(employee){    
    return new Promise((resolve, reject) => {
            Vue.http.put(url, employee).then((response) => {
            resolve(response);
            //return {error: false, data: result};
        }).catch((error) => {
            console.log(error);
            reject(error);
        });
    });
}

function updateEmployee(employee){    
    return new Promise((resolve, reject) => {
            Vue.http.post(url, employee).then((response) => {
            resolve(response);
            //return {error: false, data: result};
        }).catch((error) => {
            console.log(error);
            reject(error);
        });
    });
}

function deleteEmployee(id){   
    //debugger; 
    return new Promise((resolve, reject) => {
            Vue.http.delete(url + '/' + id).then((response) => {
            resolve(response);
            //return {error: false, data: result};
        }).catch((error) => {
            console.log(error);
            reject(error);
        });
    });
}

export default {
    getEmployees,
    getEmployee,
    addEmployee,
    updateEmployee,
    deleteEmployee
}