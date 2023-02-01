import http from 'k6/http';
import { sleep, check } from 'k6'

export let options = {
    insecureSkipTLSVerify: true,
    noConnectionReuse: false,
    stages: [
        { duration: '10s', target: 100 },
        //{ duration: '2m', target: 100 },
        //{ duration: '1m', target: 0 },
    ],
    thresholds: {
        http_req_duration: ['p(99)<100']  // 99% of requests must be bellow 20ms
    }
}

const apiUrl = 'https://localhost:7225/load';

export default () => {
    let result = http.get(`${apiUrl}/v3`);
    sleep(1);

    check(result,
        {
            "Status is 200": (r) => r.status === 200,
            "Duration < 500": (r) => r.timings.duration < 300,
        });
}

//export default () => {
//    http.get(`${apiUrl}/v2`);
//    sleep(1);
//}