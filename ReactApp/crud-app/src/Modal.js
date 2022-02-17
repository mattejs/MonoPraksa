import React, { useState } from 'react';
import axios from 'axios';
import { Input, FormGroup, Label, Modal, ModalHeader, ModalBody, ModalFooter, Table, Button } from 'reactstrap';

export default function Modals(){
    const[newBookModal, setNewBookModal] = useState(false);
    
    console.log(newBookModal);

    return(
        <Modal isOpen={newBookModal} toggle={newBookModal}>
            <ModalHeader toggle={() => setNewBookModal(!newBookModal)}>Add a new book</ModalHeader>
            <ModalBody>
                <FormGroup>
                    <Label for="title">Title</Label>
                    
                </FormGroup>
                <FormGroup>
                    <Label for="rating">Rating</Label>
                    
                </FormGroup>

            </ModalBody>
            <ModalFooter>
                <Button color="primary" >Add Book</Button>{' '}
                <Button color="secondary" >Cancel</Button>
            </ModalFooter>       
        </Modal>
    )
}