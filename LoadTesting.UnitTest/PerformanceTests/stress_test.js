import http from 'k6/http';
import { sleep } from 'k6'

export let options = {
    insecureSkipTLSVerify: true,
    noConnectionReuse: false,

    // Stress test to determine the stability of our API when number of request from users start to get in

    stages: [
        { duration: '2m', target: 500 },
        { duration: '2m', target: 600 },
        { duration: '2m', target: 800 },
        { duration: '3m', target: 1000 },
        { duration: '3m', target: 600 },
        { duration: '5m', target: 0 },

        //{ duration: '1m', target: 500 },
        //{ duration: '1m', target: 600 },
    ],
}

const apiUrl = 'https://localhost:7225/stress/'; 

//export default () => {
//    http.get(`${apiUrl}/v1`);
//    sleep(1);
//}

export default () => {

    http.batch([
        ['GET', `${apiUrl}/v1`],
        ['GET', `${apiUrl}/v2`],
    ]);

    sleep(1);
}