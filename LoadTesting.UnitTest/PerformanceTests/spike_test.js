import http from 'k6/http';
import { sleep } from 'k6'

export let options = {
    insecureSkipTLSVerify: true,
    noConnectionReuse: false,
    stages: [
        //{ duration: '2m', target: 300 },
        //{ duration: '10s', target: 2000 },
        //{ duration: '1m', target: 2000 },
        //{ duration: '10m', target: 200 },
        //{ duration: '1m', target: 0 },

        { duration: '1m', target: 300 },
        { duration: '10s', target: 2000 },
        { duration: '1m', target: 0 },
    ],
}

const apiUrl = 'https://localhost:7225/spike';

export default () => {
    http.get(`${apiUrl}/v2`);
    sleep(1);
}

//export default () => {
//    http.get(`${apiUrl}/v2`);
//    sleep(1);
//}