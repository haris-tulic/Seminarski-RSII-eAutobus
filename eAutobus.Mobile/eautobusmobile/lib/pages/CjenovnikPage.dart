import 'package:eautobusmobile/models/cjenovnik/Cjenovnik.dart';
import 'package:eautobusmobile/providers/cjenovnik_provider.dart';
import 'package:flutter/src/foundation/key.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

class CjenovnikPage extends StatefulWidget {
  static const String routeName = "Cjenovnik";
  const CjenovnikPage({Key? key}) : super(key: key);

  @override
  State<CjenovnikPage> createState() => _CjenovnikState();
}

class _CjenovnikState extends State<CjenovnikPage> {
  CjenovnikProvider? _cjenovnikProvider = null;
  List<Cjenovnik> data = [];

  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    _cjenovnikProvider = context.read<CjenovnikProvider>();
    loadData();
  }

  Future loadData() async {
    var tmpData = await _cjenovnikProvider?.get(null);
    setState(
      () {
        data = tmpData!;
      },
    );
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SingleChildScrollView(
        child: Container(
          child: Column(
            children: [
              _cjenovnikHeader(),
              Container(
                height: 200,
                child: GridView(
                  gridDelegate: SliverGridDelegateWithFixedCrossAxisCount(
                      crossAxisCount: 1,
                      childAspectRatio: 4 / 3,
                      crossAxisSpacing: 20,
                      mainAxisSpacing: 30),
                  scrollDirection: Axis.vertical,
                  children: _cjenovnikCardList(),
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }

  Widget _cjenovnikHeader() {
    return Container(
      padding: EdgeInsets.all(20),
      child: Text(
        "Cjenovnik",
        style: TextStyle(
            color: Colors.grey, fontSize: 40, fontWeight: FontWeight.w500),
      ),
    );
  }

  List<Widget> _cjenovnikCardList() {
    List<Widget> list = data
        .map(
          (x) => Container(
            height: 200,
            width: 200,
            child: Text(x.vrstaKarte ?? " "),
          ),
        )
        .cast<Widget>()
        .toList();
    return list;
  }
}
