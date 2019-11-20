import axios from 'axios'

export default {
    async addTransaction(amount, description, date){
        var data = {
            description: description,
            amount: amount,
            date: date,
        }
        return await axios.post(`/api/transaction/add`, data);
    },
    async addMonthlyTransaction(amount, description, year, month){
        return await axios.post(`/api/transactions/addMonthlyFixedTransaction?amount=${amount}&description=${description}&year=${year}&month=${month}`);
    },
    async getTransactionsForRange(dateStart, dateEnd){
        return await axios.get(`/api/transactions/rangeAll?dateStart=${dateStart}&dateEnd=${dateEnd}`);
    },
    async deleteTransction(id){
        return await axios.delete(`/api/transactions/delete?id=${id}`);
    }
}