import { Button, Col, Container, Form, Row } from "react-bootstrap";
import { Link, useNavigate, useParams } from "react-router-dom";
import { RoutesNames } from "../../constants";
import SobaService from "../../services/SobaService";
import { useEffect, useState } from "react";


export default function SobePromjena() {
    const navigate = useNavigate();
    const routeParams = useParams();
    const [soba, setSoba] = useState({});

    async function dohvatiSoba() {
        const o = await SobaService.getBySifra(routeParams.sifra);
        if (o.greska) {
            console.log(o.poruka);
            alert('pogledaj konzolu');
            return;
        }
        setSoba(o.poruka);
    }

    async function promjeni(soba) {
        const odgovor = await SobaService.put(routeParams.sifra, soba);
        if (odgovor.greska) {
            console.log(odgovor.poruka);
            alert('Pogledaj konzolu');
            return;
        }
        navigate(RoutesNames.SOBA_PREGLED);
    }

    useEffect(() => {
        dohvatiSoba();
    }, []);

    function obradiSubmit(e) { // e predstavlja event
        e.preventDefault();
       // alert('Dodajem soba');

        const podaci = new FormData(e.target);

        const soba = {
            oznaka: podaci.get('oznaka'),  // 'naziv' je name atribut u Form.Control
            kapacitet: podaci.get('kapacitet')

        };
        //console.log(routeParams.sifra);
        //console.log(smjer);
        promjeni(soba);

    }

    return (

        <Container>
            <Form onSubmit={obradiSubmit}>

                <Form.Group controlId="oznaka">
                    <Form.Label>Oznaka</Form.Label>
                    <Form.Control
                        type="text"
                        name="oznaka"
                        defaultValue={soba.oznaka}
                        required />
                </Form.Group>

                <Form.Group controlId="kapacitet">
                    <Form.Label>Kapacitet</Form.Label>
                    <Form.Control
                        type="text"
                        name="kapacitet"
                        defaultValue={soba.kapacitet}
                    />
                </Form.Group>



                <hr />
                <Row>
                    <Col>
                        <Link className="btn btn-danger siroko" to={RoutesNames.SOBA_PREGLED}>
                            Odustani
                        </Link>
                    </Col>
                    <Col>
                        <Button className="siroko" variant="primary" type="submit">
                            Promjeni
                        </Button>
                    </Col>
                </Row>

            </Form>
        </Container>

    );
}
