import moment from 'moment';

export const formatDate = (date: Date): string => moment(date).format("DD/MM/yyyy");