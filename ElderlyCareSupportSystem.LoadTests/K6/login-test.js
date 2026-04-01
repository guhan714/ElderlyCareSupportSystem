import http from 'k6/http';
import { check, sleep } from 'k6';

export const options = {
    stages: [
        { duration: '10s', target: 5 },
        { duration: '10s', target: 10 },
        { duration: '10s', target: 10 },
        { duration: '10s', target: 0 },
    ],
    thresholds: {
        http_req_duration: ['p(95)<700', 'p(99)<1000'],
    }
};

export default function () {
    
    const url = 'http://localhost:5039/auth/login';
    let res = http.get(url);
    let token = res.html()
        .find('input[name="__RequestVerificationToken"]')
        .first()
        .attr('value');
    
    const loginDetails = {
        UserName: 'admin',
        Password: 'admin123',
    };

    const params = {
        headers: {
            'Content-Type': 'application/json',
            'RequestVerificationToken': token
        }
    };

    const response = http.post(url, JSON.stringify(loginDetails), params);
    
    check(response, {
        'login success or redirect': (r) => r.status === 200 || r.status === 302,
    });
}