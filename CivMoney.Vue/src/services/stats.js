import axios from 'axios'

export default {
    async years() {
        return await axios.get('/api/transactions/yearsStats');
    },
    async getMonthStatsForYear(year) {
        return await axios.get(`/api/transactions/yearMonthStats?year=${year}`);
    }
}