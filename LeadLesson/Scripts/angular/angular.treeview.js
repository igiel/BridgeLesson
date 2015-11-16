/*
	@license Angular Treeview version 0.1.6
	ⓒ 2013 AHN JAE-HA http://github.com/eu81273/angular.treeview
	License: MIT


	[TREE attribute]
	angular-treeview: the treeview directive
	tree-id : each tree's unique id.
	tree-model : the tree model on $scope.
	node-id : each node's id
	node-label : each node's label
	node-children: each node's children

	<div
		data-angular-treeview="true"
		data-tree-id="tree"
		data-tree-model="roleList"
		data-node-id="roleId"
		data-node-label="roleName"
		data-node-children="children" >
	</div>
*/

(function ( angular ) {
	'use strict';

	angular.module( 'angularTreeview', [] ).directive( 'treeModel', ['$compile', function( $compile ) {
		return {
			restrict: 'A',
			link: function ( scope, element, attrs ) {
				//tree id
				var treeId = attrs.treeId;
			
				//tree model
				var treeModel = attrs.treeModel;

				//node id
				var nodeId = attrs.nodeId || 'id';

				//node label
				var nodeLabel = attrs.nodeLabel || 'label';

			    //node label
				var nodeExtendedLabel = attrs.nodeExtendedLabel || 'extendedLabel';

				//children
				var nodeChildren = attrs.nodeChildren || 'children';

				//data-node-click
				var nodeClick = attrs.nodeClick || '';
				//tree template
				var template =
					'<ul>' +
						'<li data-ng-repeat="node in ' + treeModel + '">' +
                            '<div class="tree-row" data-ng-class="node.selected" data-ng-click="' + treeId + '.selectNodeLabel(node); ' + nodeClick + '">' +
							    '<i class="glyphicon glyphicon-plus" data-ng-show="node.' + nodeChildren + '.length && node.collapsed" data-ng-click="' + treeId + '.selectNodeHead(node)"></i>' +
							    '<i class="glyphicon glyphicon-minus" data-ng-show="node.' + nodeChildren + '.length && !node.collapsed" data-ng-click="' + treeId + '.selectNodeHead(node)"></i>' +
							    '<i class="glyphicon glyphicon-arrow-right" data-ng-hide="node.' + nodeChildren + '.length"></i> ' +
							    '<span ' + 'ng-bind-html="node.' + nodeLabel + '"></span> ' +
                                '<span data-ng-if="node. '+ nodeExtendedLabel + '">| </span>' +
							    '<span ' + 'ng-bind-html="node.' + nodeExtendedLabel + '"></span>' +
                            '</div>' +
							'<div data-ng-hide="node.collapsed" data-tree-id="' + treeId + '" data-tree-model="node.' + nodeChildren + '" data-node-id=' + nodeId + ' data-node-label="' + nodeLabel + '" data-node-extended-label="'+ nodeExtendedLabel + '" data-node-children=' + nodeChildren + ' data-node-click="' + nodeClick + '"></div>' +
						'</li>' +
					'</ul>';


				//check tree id, tree model
				if( treeId && treeModel ) {

					//root node
					if( attrs.angularTreeview ) {
					
						//create tree object if not exists
						scope[treeId] = scope[treeId] || {};

						//if node head clicks,
						scope[treeId].selectNodeHead = scope[treeId].selectNodeHead || function( selectedNode ){

							//Collapse or Expand
							selectedNode.collapsed = !selectedNode.collapsed;
						};

						//if node label clicks,
						scope[treeId].selectNodeLabel = scope[treeId].selectNodeLabel || function( selectedNode ){

							//remove highlight from previous node
							if( scope[treeId].currentNode && scope[treeId].currentNode.selected ) {
								scope[treeId].currentNode.selected = undefined;
							}

							//set highlight to selected node
							selectedNode.selected = 'selected';

							//set currentNode
							scope[treeId].currentNode = selectedNode;


						};
					}

					//Rendering template.
					element.html('').append( $compile( template )( scope ) );
				}
			}
		};
	}]);
})( angular );
