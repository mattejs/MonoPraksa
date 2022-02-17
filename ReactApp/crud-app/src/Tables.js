import axios from 'axios';
import React, { useEffect, useState } from 'react';
import { Table, Button, CardHeader, Container, Modal, ModalBody, ModalFooter, FormGroup, ModalHeader, Label, Input } from 'reactstrap';

export default function Tables() {
    const [users, setUsers] = useState([]);
    const [newUserModal, setNewUserModal] = useState(false);
    const [newBookData, setNewBookData] = useState({username:'',email:''});

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
        axios.post('https://localhost:44343/users', newBookData).then((response) => {
          
          console.log(response.data);
    
          users.push(response.data);
    
          setNewBookData({ users, newUserModal: false, newBookData: {
            username: '',
            email: ''
          }});
        });
      }

    const getData = () => {
        axios.get('https://localhost:44343/users')
            .then((getData) => {
                setUsers(getData.data);
            })
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
                    <Label for="username">Username:</Label>
                    <Input id="username" value={newBookData} onChange={(e) => {

                    newBookData.username = e.target.value;

                    setNewBookData({ newBookData });
                    }} />
                </FormGroup>
                <ModalFooter>
                    <Button color="primary" onClick={() => AddUser()}>Add User</Button>{' '}                    
                    <Button color="secondary" onClick={() => setNewUserModal(!newUserModal)} >Cancel</Button>
                </ModalFooter>

                </ModalBody>
                
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