import http from 'k6/http';
import { sleep } from 'k6'

export let options = {
    insecureSkipTLSVerify: true,
    noConnectionReuse: false,
    vus: 1,
    duration: '10s'
}

const apiUrl = 'https://localhost:7225/load/';

export default () => {
    http.get(`${apiUrl}/v1`);
    sleep(1);
}

//export default () => {
//    http.get(`${apiUrl}/v2`);
//    sleep(1);
//}

//export default () => {
//    http.get(`${apiUrl}/v3`);
//    sleep(1);
//}