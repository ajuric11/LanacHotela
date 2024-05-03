import { Button, Col, Container, Form, Row } from "react-bootstrap";
import { Link, useNavigate } from "react-router-dom";
import { RoutesNames } from "../../constants";
import SobaService from "../../services/SobaService";


export default function SobeDodaj() {
    const navigate = useNavigate();

    async function dodaj(soba) {
        const odgovor = await SobaService.post(soba);
        if (odgovor.greska) {
            console.log(odgovor.poruka);
            alert('Pogledaj konzolu');
            return;
        }
        navigate(RoutesNames.SOBA_PREGLED);
    }

    function obradiSubmit(e) { // e predstavlja event
        e.preventDefault();
        //alert('Dodajem sobe');

        const podaci = new FormData(e.target);

        const soba = {
            oznaka: podaci.get('oznaka'),
            kapacitet: podaci.get('kapacitet'),


        };

        // console.log(klijent);
        dodaj(soba);

    }

    return (

        <Container>
            <Form onSubmit={obradiSubmit}>

                <Form.Group controlId="oznaka">
                    <Form.Label>Oznaka</Form.Label>
                    <Form.Control type="text" name="oznaka" required />
                </Form.Group>

                <Form.Group controlId="kapacitet">
                    <Form.Label>Kapacitet</Form.Label>
                    <Form.Control type="text" name="kapacitet" />
                </Form.Group>




                <hr />
                <Row>
                    <Col xs={6} sm={6} md={3} lg={6} xl={1} xxl={2}>
                        <Link className="btn btn-danger siroko" to={RoutesNames.SOBA_PREGLED}>
                            Odustani
                        </Link>
                    </Col>
                    <Col xs={6} sm={6} md={9} lg={6} xl={1} xxl={10}>
                        <Button className="siroko" variant="primary" type="submit">
                            Dodaj
                        </Button>
                    </Col>
                </Row>

            </Form>
        </Container>

    );
}