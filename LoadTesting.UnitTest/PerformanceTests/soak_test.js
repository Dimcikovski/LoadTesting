import http from 'k6/http';
import { sleep } from 'k6'

// good to find memory leak, bloated logs, database exhaustion

export let options = {
    insecureSkipTLSVerify: true,
    noConnectionReuse: false,
    stages: [
        { duration: '2m', target: 200 },
        { duration: '4h', target: 2000 },
        { duration: '2m', target: 0 },
    ],
}

const apiUrl = 'https://localhost:7225/soak';

export default () => {

    http.batch([
        ['GET', `${apiUrl}/v1`],
        ['GET', `${apiUrl}/v2`],
    ]);

    sleep(1);
}