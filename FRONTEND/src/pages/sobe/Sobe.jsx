import { useEffect, useState } from 'react';
import Container from 'react-bootstrap/Container';
import SobaService from '../../services/SobaService';
import { Button, Table } from 'react-bootstrap';
import { Link, useNavigate } from 'react-router-dom';
import { RoutesNames } from '../../constants'


export default function Sobe() {
    const [sobe, setSobe] = useState();
    const navigate = useNavigate();



    async function dohvatiSobe() {
        await SobaService.get()
            .then((odg) => {
                setSobe(odg);
            })
            .catch((e) => {
                console.log(e);
            });
    }

    useEffect(() => {
        dohvatiSobe();
    }, []);



    async function obrisiAsync(id) {
        const odgovor = await SobaService._delete(id);
        if (odgovor.greska) {
            console.log(odgovor.poruka);
            alert('Pogledaj konzolu');
            return;
        }
        dohvatiSobe();
    }

    function obrisi(id) {
        obrisiAsync(id);
    }

    return (
        <>
            <Container>
                <Link to={RoutesNames.SOBA_NOVI}> Dodaj </Link>
                <Table striped bordered hover responsive>
                    <thead>
                        <tr>
                            <th>Oznaka</th>
                            <th>Kapacitet</th>

                        </tr>
                    </thead>
                    <tbody>
                        {sobe && typeof sobe === 'object' && Array.isArray(sobe) && sobe.map((soba, index) => (

                            <tr key={index}>
                                <td>{index + 1}</td>
                                <td>{soba.oznaka}</td>
                                <td>{soba.kapacitet}</td>

                                <td>

                                </td>
                                <td>
                                    <Button
                                        onClick={() => obrisi(soba.sifra)}
                                        variant='danger'
                                    >
                                        Obriši
                                    </Button>
                                    <Button
                                        onClick={() => { navigate(`/sobe/${soba.sifra}`) }}
                                    >
                                        Promjeni
                                    </Button>
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </Table>
            </Container>
        </>
    );
}