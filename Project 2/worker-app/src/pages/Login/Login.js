import React, { useState } from "react";
import {
  Button,
  Form,
  Col,
  FormGroup,
  FormControl,
  FormLabel,
  Row,
  Container,
} from "react-bootstrap";
import { useDispatch } from "react-redux";
import { authActions } from "../../actions/authActions";

const Login = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const dispatch = useDispatch();

  function validateForm() {
    return email.length > 0 && password.length > 0;
  }

  function handleSubmit(event) {
    event.preventDefault();
    event.stopPropagation();
    dispatch(authActions.login(email, password));
  }

  return (
    <>
    <Container style={{marginTop: "2em", display: 'flex',  justifyContent:'center', alignItems:'center'}}className="justify-content-center align-items-center">
      <h1 style={{color:"#5a6268"}}>Enterprising - LOGIN</h1>
    </Container>
    <Container>
      <Row>
        <Col>
          <Form onSubmit={handleSubmit}>
            <FormGroup controlId="email">
              <FormLabel>Email</FormLabel>
              <FormControl
                autoFocus
                type="email"
                value={email}
                onChange={(e) => setEmail(e.target.value)}
              />
            </FormGroup>
            <FormGroup controlId="password">
              <FormLabel>Password</FormLabel>
              <FormControl
                value={password}
                onChange={(e) => setPassword(e.target.value)}
                type="password"
              />
            </FormGroup>

            <Button style={{backgroundColor:"#5a6268", borderColor:"#5a6268"}}block disabled={!validateForm()} type="submit">
              Login
            </Button>
          </Form>
        </Col>
      </Row>
      <Row className="justify-content-center">
        <Col>
          Do you not have an account? <a style={{color:"#5a6268"}} href="/register"> Register </a>
        </Col>
      </Row>
    </Container>
    </>
  );
};

export default Login;
