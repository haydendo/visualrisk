function renderChart(data) {    
    var labels = [], values = [];
    $.each(data, function (i, value) {
        labels.push(value.DiscountRateLabel);
        values.push(value.NetPresentValue);
    });
    
    var npvChart = new Chart($('#npvChart'), {
        type: 'bar',
        data: {
            labels: labels,
            datasets: [{
                label: 'Net Present Value',
                data: values,               
                borderWidth: 1,
                backgroundColor: '#f38b4a'
            }]            
        },
        options: {            
            title: {
                display: true,
                text: 'Net Present Value for Discount Rates'
            },
            legend: { display: false },
            scales: {
                yAxes: [{
                    ticks: {
                        beginAtZero: true
                    }
                }]
            }
        }
    });    
};

function CashFlow(number, amount) {
    var self = this;
    self.number = number;
    self.amount = amount;
    self.name = 'CashFlows';
}

function FinanceViewModel() {
    
    self = this;

    self.menuItems = ['API', 'Help'];

    self.gotoMenu = function (menu) {
        location.hash = menu;
    };  

    self.cashFlows = ko.observableArray([
        new CashFlow(0, 100)
    ]);

    self.addCashFlow = function () {
        self.cashFlows.push(new CashFlow(1, 100));
    };

    self.removeCashFlow = function (cashFlow) {
        self.cashFlows.remove(cashFlow)
    }

    self.calculate = () => {
        
        $.ajax({
            url: 'api/finance',
            type: "POST",
            data: $("form").serialize(),
            success: function (result) {
                renderChart(result);                
            },
            error: function (error) {
                console.log(error)
            }
        });
    }

    Sammy(function () {
        this.get('#API', function () {
            //TODO: Render and use template
            alert('Render API page');
        });
        this.get('#Help', function () {
            //TODO: Render and use template
            alert('Render Help page');
        });
    }).run();
};

ko.applyBindings(new FinanceViewModel());