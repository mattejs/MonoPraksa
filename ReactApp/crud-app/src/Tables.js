import axios from 'axios';
import React, { useEffect, useState } from 'react';
import { Table, Button, CardHeader, Container, Modal, ModalBody, ModalFooter, FormGroup, ModalHeader, Label, Input } from 'reactstrap';

export default function Tables() {
    const [users, setUsers] = useState([]);
    const [username, setUsername] = useState("");
    const [email, setEmail] = useState("");
    const [newUserModal, setNewUserModal] = useState(false);
    const [editUserModal, setEditUserModal] = useState(false);
    const [editId, setEditId] = useState("");
    const [editUsername, setEditUsername] = useState("");
    const [editEmail, setEditEmail] = useState("");

    useEffect(() => {
        axios.get('https://localhost:44343/users')
            .then((response) => {
                console.log(response.data)
                setUsers(response.data);
            })
    }, []);

    const setData = (data) => {
        let { id, username, email } = data;
        localStorage.setItem('Id', id);
        localStorage.setItem('Username', username);
        localStorage.setItem('Email', email)
    }
    const AddUser = () => {
        const newUserData = {Username : username,
                             Email : email};
        axios.post('https://localhost:44343/users', newUserData).then((response) => {
          setData(response.data);
          setUsername('');
          setEmail('');
          console.log(response.data);
          console.log(newUserData);
          
    
          users.push(response.data);
          //getData(); 
        });
      }

    const getData = () => {
        axios.get('https://localhost:44343/users')
            .then((getData) => {
                setUsers(getData.data);
            })
    }

    const onUpdate = () => {
        const newUserData = {Id:editId,Username:editUsername,Email:editEmail}
        console.log(newUserData)
        axios.put('https://localhost:44343/users/' + editId, newUserData)
        .then((response)=>{
            setData(response.data);    
            getData();
        });
        //const data = setEditData(editData);
        //console.log(data); 
        
    }

    const putData = (id,name,email) => {
        setEditId(id);        
        setEditUsername(name);
        setEditEmail(email);

        const editData={id:id,username:editUsername,email:editEmail};
        console.log(editData);
        setEditUserModal(!editUserModal);
    }

    const onDelete = (id) => {
        axios.delete('https://localhost:44343/users/' + id)
        .then(() => {
            getData();
        })
    }

    let usersList = users.map((user) => {
        return (
          <tr key={user.Id}>
            <td>{user.Id}</td>
            <td>{user.Username}</td>
            <td>{user.Email}</td>
            <td>
                <Button color="success" size="sm" className="mr-2" onClick={() => putData(user.Id, user.Username, user.Email)}>Edit</Button>
                <Button color="danger" size="sm" onClick={() => onDelete(user.Id)}>Delete</Button>
            </td>            
          </tr>
        )
      });

    return (
        
        <Container>
            <h1>Users table</h1>

            <Button className="my-3" color="primary" onClick={() => setNewUserModal(!newUserModal)}>Add User</Button>

            <Modal isOpen={newUserModal} toggle={() => setNewUserModal(!newUserModal)}>
                <ModalHeader toggle={() => setNewUserModal(!newUserModal)}>Add new user</ModalHeader>
                <ModalBody>
                <FormGroup>
                    <Label for="Username">Username:</Label>
                    <Input id="Username" value={username} onChange={(e) => setUsername(e.target.value)} />
                </FormGroup>
                <FormGroup>
                    <Label for="Email">Email:</Label>
                    <Input id="Email" value={email} onChange={(e) => setEmail(e.target.value)} />
                </FormGroup>
                <ModalFooter>
                    <Button color="primary" onClick={() => AddUser()}>Add User</Button>{' '}                    
                    <Button color="secondary" onClick={() => setNewUserModal(!newUserModal)} >Cancel</Button>
                </ModalFooter>

                </ModalBody>
                
            </Modal>

            <Modal isOpen={editUserModal} toggle={()=>setEditUserModal(!editUserModal)}>
                <ModalHeader toggle={()=>setEditUserModal(!editUserModal)}>Edit user</ModalHeader>
                <ModalBody>
                    <FormGroup>
                        <Label for="Username">Username</Label>
                        <Input id="Username" value={editUsername} onChange={(e) => {
                        setEditUsername(e.target.value)
                        }} />
                    </FormGroup>
                    <FormGroup>
                        <Label for="Email">Email</Label>
                        <Input id="Email" value={editEmail} onChange={(e) => {
                        setEditEmail(e.target.value)
                        }} />
                    </FormGroup>

                </ModalBody>
                <ModalFooter>
                    <Button color="primary" onClick={() => onUpdate()}>Update User</Button>{' '}
                    <Button color="secondary" onClick={() => setEditUserModal(!editUserModal)}>Cancel</Button>
                </ModalFooter>
             </Modal>
            

            <Table>
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Username</th>
                        <th>Email</th>
                        <th>Actions</th>
                    </tr>
                </thead>

                <tbody>
                    {usersList}
                </tbody>
            </Table> 
        </Container>
    )
}