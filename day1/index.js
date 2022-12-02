import fs from 'fs/promises';

const r = async () => {
    const data = await fs.readFile('../day1input', { encoding: 'utf8' });
    return data.split('\n\n');
}

const data = await r();
const max = Math.max(...data.map(x => {
    const red = x.split('\n').filter(y => y !== '').reduce((a, b) => parseInt(a) + parseInt(b), 0);
    return red;
}));

console.log(max);